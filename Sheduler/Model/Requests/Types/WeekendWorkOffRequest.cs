using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model.Requests
{
    public class WeekendWorkOffRequest : RestRequest
    {
        public override string Type => "В выходной за счет отработки";
        
        [FormField(FormFieldType.Date)]
        public ISet<DateTime> WorkOffDates { set; get; }
    }
}
