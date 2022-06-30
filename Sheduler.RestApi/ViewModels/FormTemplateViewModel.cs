using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sheduler.RestApi.Services.ToFormConverter;

namespace Sheduler.RestApi.ViewModels
{
    public record FormTemplateViewModel(IEnumerable<FormField> Template);
}
