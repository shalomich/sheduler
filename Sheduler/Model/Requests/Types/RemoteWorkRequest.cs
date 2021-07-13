using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model.Requests
{
    [FormModel]
    public class RemoteWorkRequest : Request
    {
        public override string Type => "На удаленную работу";
        
        [FormField(FormFieldType.TextArea,false)]
        public string WorkingPlan { set; get; }
    }
}
