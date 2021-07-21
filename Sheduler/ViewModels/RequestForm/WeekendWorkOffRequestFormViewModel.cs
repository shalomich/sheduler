using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels.RequestForm
{
    [FormModel("weekendWorkOffRequest")]
    public class WeekendWorkOffRequestFormViewModel : RestRequestFormModel
    {
        [FormField(FormFieldType.Date, "Даты отработки")]
        public ISet<DateTime> WorkOffDates { set; get; }
    }
}
