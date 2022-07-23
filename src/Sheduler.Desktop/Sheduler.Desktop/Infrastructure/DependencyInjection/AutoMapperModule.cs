using Microsoft.Extensions.DependencyInjection;
using Sheduler.Mvvm.ViewModels.Products;
using Sheduler.UseCases.Users;

namespace Sheduler.Desktop.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Register AutoMapper dependencies.
    /// </summary>
    public class AutoMapperModule
    {
        /// <summary>
        /// Register dependencies.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void Register(IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(UserMappingProfile),
                typeof(ProductsMappingProfile));
        }
    }
}
