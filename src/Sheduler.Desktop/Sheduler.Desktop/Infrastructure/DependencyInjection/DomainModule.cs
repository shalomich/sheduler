using Microsoft.Extensions.DependencyInjection;
using Sheduler.DomainServices.Store;

namespace Sheduler.Desktop.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Register domain dependencies.
    /// </summary>
    internal static class DomainModule
    {
        /// <summary>
        /// Register dependencies.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<ProductSkuValidator>();
        }
    }
}
