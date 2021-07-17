using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    [FormModel("Request")]
    public class RequestFormViewModel
    {
        public int Id { set; get; }

        [FormField(FormFieldType.Select)]
        public string Type { set; get; }

        [FormField(FormFieldType.Date)]
        public ISet<DateTime> ChoosendDates { set; get; }

        [FormField(FormFieldType.TextArea, false)]
        public string Comment { set; get; }

        [FormField(FormFieldType.Select, false)]
        public int ReplacingId { set; get; }

        [FormField(FormFieldType.Select, false)]
        public int ApprovingId { set; get; }

        [FormField(FormFieldType.TextArea, false)]
        public string WorkingPlan { set; get; }

        [FormField(FormFieldType.Select)]
        public string VacationType { set; get; }

        [FormField(FormFieldType.RadioButton)]
        public bool IsDateChangeable { set; get; } = false;

        [FormField(FormFieldType.Date)]
        public ISet<DateTime> WorkOffDates { set; get; }
    }
}
