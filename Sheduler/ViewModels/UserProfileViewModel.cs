using Sheduler.Extensions;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record UserProfileViewModel(int Id, string Email, string PhoneNumber,
        string Name, UserRole Role, string Post) : UserSummaryViewModel(Id,Name,Role,Post)
    {
        public int  WorkedDaysPerYear {init; get; }
        public int UnusedVacationDaysPerYear {init; get; }
        public int UnusedVacationDaysLastYears {init; get; }
        public int  DayOfQuantity {init; get; }
    }
}
