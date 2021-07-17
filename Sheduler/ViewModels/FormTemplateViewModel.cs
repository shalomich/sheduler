using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sheduler.Services.ToFormConverter;

namespace Sheduler.ViewModels
{
    public record FormTemplateViewModel(IEnumerable<FormField> Template);
}
