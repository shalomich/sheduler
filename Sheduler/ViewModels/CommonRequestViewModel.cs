using Newtonsoft.Json;
using Sheduler.Model.Requests;
using Sheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public class CommonRequestViewModel
    {
        public int Id { set; get; }
        public string CreatorName { set; get; }
        public string Type { set; get; }
        public string SendingDate { set; get; }        
        public string ChoosendDates { set; get; }
        public int? DayQuantity { set; get; }
        public string ApprovingName { set; get; }
        public string Status { set; get; }
    }
}
