using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Sheduler.RestApi.Controllers;
using Sheduler.RestApi.Model;
using Sheduler.RestApi.Services;
using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Sheduler.RestApi.Extensions;
using Sheduler.RestApi.Services.Logger;
using System.Text.Json.Serialization;
using Sheduler.RestApi.Middlewares.ExceptionHandler;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Mvc;

namespace Sheduler
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<ApplicationContext>();

            services.Configure<AuthOptions>(Configuration.GetSection(nameof(AuthOptions)));

            AuthOptions authOptions = Configuration.GetSection(nameof(AuthOptions)).Get<AuthOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = authOptions.Issuer,
                            ValidateAudience = true,
                            ValidAudience = authOptions.Audience,
                            ValidateLifetime = true,
                            IssuerSigningKey = authOptions.GenerateSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });
            services.AddAuthorization();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddMediatR(typeof(Startup).Assembly);

            var loggerFactory = new LoggerFactory();
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logs.txt"));
            var logger = loggerFactory.CreateLogger<FileLogger>();
            services.AddSingleton<ILogger>(logger);

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<ToFormConverter>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
                
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });

        }
    }
}
