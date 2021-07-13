using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Attributes.GenericControllerName
{
    public interface IGenericTypeStrategy
    {
        public Type ControllerType { get; }
        public IEnumerable<Type> GetTypes();
    }
}
