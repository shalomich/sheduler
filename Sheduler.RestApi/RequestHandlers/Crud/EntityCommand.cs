using Sheduler.RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.RequestHandlers.Crud
{
    public record EntityCommand(IEntity Entity);
}
