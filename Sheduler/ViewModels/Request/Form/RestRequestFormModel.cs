using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels.RequestForm
{
    public abstract class RestRequestFormModel : RequestFormModel
    {
        [FormField(FormFieldType.Select, "Замещающий", false, "user/replacing")]
        public int ReplacingId { set; get; }
    }
}
