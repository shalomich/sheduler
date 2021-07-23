using Sheduler.Attributes;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels.RequestForm
{
    [FormModel("vacationRequest")]
    public class VacationRequestFormViewModel : RestRequestFormModel
    {
        [FormField(FormFieldType.Select, "Тип отпуска", true, "request/vacationType")]
        public VacationType VacationType { set; get; }
    }
}
