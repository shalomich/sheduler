using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model.Requests
{
    [FormModel]
    public class DayOffRequest : RestRequest
    {
        public override string Type => "На отгул";
    }
}
