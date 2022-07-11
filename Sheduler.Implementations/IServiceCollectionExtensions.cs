using Microsoft.Extensions.DependencyInjection;
using Sheduler.Abstractions;

namespace Sheduler.Implementations;
public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAbstractionImplementations(this IServiceCollection services)
    {
        services.AddSingleton<IAuthTokenProvider>(new AuthTokenProvider());

        return services;
    }
}

