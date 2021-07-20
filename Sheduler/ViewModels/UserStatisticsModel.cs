using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record UserStatisticsModel(int WorkedDaysPerYear,int UnusedVacationDaysPerYear,
        int UnusedVacationDaysLastYears, int DayOfQuantity);
}
