using Newtonsoft.Json;
using Sheduler.Extensions;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record UserProfileViewModel(int Id)
    {
        [JsonProperty("ФИО")]
        public string Name { get; init; }

        [JsonProperty("Роль")]
        public string Role { get; init; }

        [JsonProperty("Должность")]
        public string Post { get; init; }
        public string Email { get; init; }

        [JsonProperty("Номер телефона")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Количество отработанных дней в текущем году")]
        public int WorkedDaysPerYear { get; set; }

        [JsonProperty("Количество неиспользованных дней отпуска в текущем году")]
        public int UnusedVacationDaysPerYear { get; set; }

        [JsonProperty("Количество неиспользованных дней отпуска за прошедшие года")]
        public int UnusedVacationDaysLastYears { get; set; }

        [JsonProperty("Количества отгулов в текущем году")]
        public int DayOffQuantity { get; set; }
    }
}
