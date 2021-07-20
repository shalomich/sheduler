using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public class FullRequestViewModel
    {
        public int Id { set; get; }
        public string Type { set; get; }
        public string Status { set; get; }
        public ISet<DateTime> ChoosendDates { set; get; }
        public DateTime CreationDate { set; get; }
        public DateTime? SendingDate { set; get; }
        public string ApprovingName { set; get; }
        public string Comment { set; get; }
        public string ReplacingName { set; get; }
        public int CreatorId { set; get; }
        public string WorkingPlan { set; get; }

        public string VacationType { set; get; }

        public bool? IsDateChangeable { set; get; }

        public ISet<DateTime> WorkOffDates { set; get; }
    }
}
