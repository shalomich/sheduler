using Sheduler.RestApi.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.ViewModels
{
    public abstract class RequestFormModel
    {
        public int Id { set; get; }

        [FormField(FormFieldType.Date, "Даты на заявку")]
        public ISet<DateTime> ChoosendDates { set; get; }

        [FormField(FormFieldType.TextArea, "Комментарий", false)]
        public string Comment { set; get; }

        [FormField(FormFieldType.Select, "Согласующий", false, "user/approving")]
        public int ApprovingId { set; get; }
    }
}
