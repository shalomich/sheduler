using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Sheduler.Attributes;
using Sheduler.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sheduler.Services
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var genericControllers = GetType().Assembly.GetTypes()
                .Where(type => type.BaseType == typeof(Controller)
                    && type.IsGenericType);

            foreach (var controller in genericControllers)
            {
                var attribute = controller.GetCustomAttribute<GenericControllerAttribute>();

                if (attribute != null)
                {
                    foreach (var genericType in attribute.GetGenerticTypes())
                    {
                        var controllerTypeInfo = attribute.ControllerType
                            .MakeGenericType(genericType)
                            .GetTypeInfo();

                        feature.Controllers.Add(controllerTypeInfo);
                    }
                }
            }
        }
    }
}
