using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Desktop.Infrastructure.Authentication;
using Sheduler.Infrastructure.Abstractions.Interfaces;
using Sheduler.Infrastructure.DataAccess;

namespace Sheduler.Desktop.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Register identity dependencies.
    /// </summary>
    internal static class IdentityModule
    {
        /// <summary>
        /// Register dependencies.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<Domain.Users.Entities.User, Domain.Users.Entities.AppIdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
            });

            var currentUserService = new CurrentUserService(configuration);
            services.AddSingleton<ICurrentUserSetter>(currentUserService);
            services.AddSingleton<ICurrentUserAccessor>(currentUserService);
        }
    }
}
