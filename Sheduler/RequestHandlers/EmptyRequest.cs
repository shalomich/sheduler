using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RequestHandlers
{
    public class EmptyRequest<T> : IRequest<T>
    {
    }
}
