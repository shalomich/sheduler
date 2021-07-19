using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model.Requests
{
    public class VacationRequest : RestRequest
    {
        public override string Type => "На отпуск";
        
        public string VacationType { set; get; }
        
        public bool IsDateChangeable { set; get; } = false;
    }
}
