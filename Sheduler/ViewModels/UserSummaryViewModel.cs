using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record UserSummaryViewModel(int Id, string Name, UserRole Role,string Post);
}
