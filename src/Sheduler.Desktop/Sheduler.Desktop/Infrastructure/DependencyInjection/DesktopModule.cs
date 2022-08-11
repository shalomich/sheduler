using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Desktop.Infrastructure.Navigation;
using Sheduler.Infrastructure.Common.Configuration;
using Sheduler.Mvvm.ServiceAbstractions;

namespace Sheduler.Desktop.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Registers WPF-specific dependencies and some basic application dependencies.
    /// </summary>
    internal static class DesktopModule
    {
        /// <summary>
        /// Register dependencies.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            LoggingModule.Register(services, configuration);
            services.AddSingleton<INotificationService, NotificationService>();
            services.AddSingleton<IUiContext, UiContext>(provider => new UiContext(Application.Current.Dispatcher));
            services.Configure<UIConfiguration>(configuration.GetSection("AppSettings").GetSection("UI"));

            NavigationModule.Register(services);
            MediatRModule.Register(services);
            IdentityModule.Register(services, configuration);
            AutoMapperModule.Register(services);
            DatabaseModule.Register(services, configuration);
            DomainModule.Register(services);
        }
    }
}
