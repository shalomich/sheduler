using Sheduler.RestApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Model.Requests
{
    public class DayOffRequest : RestRequest
    {
        public override string Type => "На отгул";
    }
}
