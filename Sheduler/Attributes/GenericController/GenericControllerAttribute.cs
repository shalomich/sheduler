using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Sheduler.Attributes.GenericControllerName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)] 
    public class GenericControllerAttribute : Attribute, IControllerModelConvention 
    { 
        private IGenericTypeStrategy GenericStrategy { get; }

        public Type ControllerType => GenericStrategy.ControllerType;

        public GenericControllerAttribute(Type GenericStrategyType)
        {
            var strategy = Activator.CreateInstance(GenericStrategyType) as IGenericTypeStrategy;

            if (strategy == null)
                throw new ArgumentException();

            GenericStrategy = strategy;
        }

        public IEnumerable<Type> GetGenerticTypes()
        {
            return GenericStrategy.GetTypes();
        }

        public void Apply(ControllerModel controller) 
        {  
            var entityType = controller.ControllerType.GenericTypeArguments[0]; 
            controller.ControllerName = entityType?.Name; 
        } 
    }
}
