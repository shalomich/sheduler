using Sheduler.Attributes;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model.Requests
{
    public abstract class RestRequest : Request
    {
        [FormField(FormFieldType.Select, false)]
        public User Replacing { set; get; }
        public int? ReplacingId { set; get; }
    }
}
