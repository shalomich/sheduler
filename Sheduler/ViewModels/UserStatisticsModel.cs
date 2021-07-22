using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record UserStatisticsModel() 
    { 
        [JsonProperty("Количество отработанных дней в текущем году")]
        public int WorkedDaysPerYear { get; init; }

        [JsonProperty("Количество неиспользованных дней отпуска в текущем году")]
        public int UnusedVacationDaysPerYear { get; init; }

        [JsonProperty("Количество неиспользованных дней отпуска за прошедшие года")]
        public int UnusedVacationDaysLastYears { get; init; } 
        
        [JsonProperty("Количества отгулов в текущем году")]
        public int DayOffQuantity { get; init; }
    }
}
