using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Desktop.Infrastructure.Startup;
using Sheduler.Infrastructure.Abstractions.Interfaces;
using Sheduler.Infrastructure.DataAccess;

namespace Sheduler.Desktop.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Register database dependencies.
    /// </summary>
    internal static class DatabaseModule
    {
        /// <summary>
        /// Register dependencies.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var migrationAssembly = typeof(AppDbContext).Assembly.GetName().Name;
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("AppDatabase") ?? throw new ArgumentNullException("AppDatabase"),
                sqlOptions => sqlOptions.MigrationsAssembly(migrationAssembly)
            ));
            services.AddTransient<DatabaseInitializer>();
            services.AddScoped<IAppDbContext, AppDbContext>();
        }
    }
}
