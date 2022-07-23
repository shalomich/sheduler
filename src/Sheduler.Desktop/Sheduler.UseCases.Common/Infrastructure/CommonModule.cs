using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.UseCases.Common.Behaviors;
using Sheduler.UseCases.Common.DependencyInjection;

namespace Sheduler.UseCases.Common.Infrastructure
{
    public static class CommonModule
    {
        /// <summary>
        /// Register dependencies.
        /// </summary>
        /// <param name="services">Services.</param>
        public static void Register(IServiceCollection services)
        {
            services.AddTransient(typeof(Lazy<>), typeof(LazyProvider<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CancellationHandlingBehavior<,>));
        }
    }
}
