using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model.Requests
{
    [FormModel]
    public class VacationRequest : RestRequest
    {
        public override string Type => "На отпуск";
        
        [FormField(FormFieldType.Select)]
        public string VacationType { set; get; }
        
        [FormField(FormFieldType.RadioButton)]
        public bool IsDateChangeable { set; get; } = false;
    }
}
