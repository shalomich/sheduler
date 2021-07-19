using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    [FormModel("request")]
    public class RequestFormViewModel
    {
        public int Id { set; get; }

        [FormField(FormFieldType.Select, "Тип заявки")]
        public string Type { set; get; }

        [FormField(FormFieldType.Date, "Даты на заявку")]
        public ISet<DateTime> ChoosendDates { set; get; }

        [FormField(FormFieldType.TextArea, "Комментарий", false)]
        public string Comment { set; get; }

        [FormField(FormFieldType.Select, "Замещающий", false)]
        public int ReplacingId { set; get; }

        [FormField(FormFieldType.Select, "Согласующий", false)]
        public int ApprovingId { set; get; }

        [FormField(FormFieldType.TextArea, "Рабочий план", false)]
        public string WorkingPlan { set; get; }

        [FormField(FormFieldType.Select, "Тип отпуска")]
        public string VacationType { set; get; }

        [FormField(FormFieldType.RadioButton, "Возможность редактирования дат согласующим")]
        public bool IsDateChangeable { set; get; } = false;

        [FormField(FormFieldType.Date, "Даты отработки")]
        public ISet<DateTime> WorkOffDates { set; get; }
    }
}
