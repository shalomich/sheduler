using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RequestHandlers
{
    public interface IByIdRequest
    {
        public int Id { set; get; }
    }
}
