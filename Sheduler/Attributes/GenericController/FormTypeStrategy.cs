using Sheduler.Attributes.GenericControllerName;
using Sheduler.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Attributes.GenericController
{
    public class FormTypeStrategy : IGenericTypeStrategy
    {
        public Type ControllerType => typeof(FormController<>);

        public IEnumerable<Type> GetTypes()
        {
            return GetType().Assembly.GetTypes()
                .Where(type => type.CustomAttributes
                    .Any(attribute => attribute.AttributeType == typeof(FormModelAttribute)))
                .ToList();
        }
    }
}
