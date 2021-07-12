using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model.Requests
{
    public abstract class RestRequest : Request
    {
        public User Replacing { set; get; }
        public int? ReplacingId { set; get; }
    }
}
