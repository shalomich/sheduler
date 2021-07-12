using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model.Requests
{
    public class WeekendVacationRequest : RestRequest
    {
        public override string Type => "На выходной в счет отпуска";
    }
}
