using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record OptionViewModel(IEnumerable<OptionModel> Options);
}
