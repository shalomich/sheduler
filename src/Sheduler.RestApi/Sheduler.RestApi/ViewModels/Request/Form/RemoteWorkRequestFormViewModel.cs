using Sheduler.RestApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.ViewModels.RequestForm
{
    [FormModel("remoteWorkRequest")]
    public class RemoteWorkRequestFormViewModel : RequestFormModel
    {
        [FormField(FormFieldType.TextArea, "Рабочий план", false)]
        public string WorkingPlan { set; get; }
    }
}
