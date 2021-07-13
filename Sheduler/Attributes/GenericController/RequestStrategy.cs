using Sheduler.Attributes.GenericControllerName;
using Sheduler.Controllers;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Attributes.GenericController
{
    public class RequestStrategy : IGenericTypeStrategy
    {
        public Type ControllerType => typeof(RequestByTypeController<>);

        public IEnumerable<Type> GetTypes()
        {
            return GetType().Assembly.GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Request)) && type.IsAbstract == false);
        }
    }
}
