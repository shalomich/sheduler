using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

namespace Sheduler.UseCases
{
    public static class UseCasesModule
    {
        public static IServiceCollection Register(IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(new RestClient(configuration["AppSettings:ApiBaseUrl"]));

            return services;
        }
    }
}
