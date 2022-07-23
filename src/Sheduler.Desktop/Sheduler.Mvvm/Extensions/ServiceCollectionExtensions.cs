using System;
using Sheduler.Mvvm.Utils.Validation;

namespace Sheduler.Mvvm.Extensions
{
    /// <summary>
    /// Extensions class for register services.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Runs logic after service provider has been generated.
        /// </summary>
        public static void PostRegisterMvvm(this IServiceProvider serviceProvider)
        {
            ModelValidator.SetServiceProvider(serviceProvider);
        }
    }
}
