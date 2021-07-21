using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels.RequestForm
{
    public class FullRequestFormViewModel
    {
        public int Id { set; get; }
        public ISet<DateTime> ChoosendDates { set; get; }
        public string Comment { set; get; }
        public int ReplacingId { set; get; }
        public int ApprovingId { set; get; }
        public string WorkingPlan { set; get; }
        public VacationType VacationType { set; get; }
        public bool IsDateChangeable { set; get; } = false;
        public ISet<DateTime> WorkOffDates { set; get; }
    }
}
