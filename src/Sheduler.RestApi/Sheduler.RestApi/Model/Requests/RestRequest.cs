using Sheduler.RestApi.Attributes;
using Sheduler.RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Model.Requests
{
    public abstract class RestRequest : Request
    {
        public User Replacing { set; get; }
        public int? ReplacingId { set; get; }
    }
}
