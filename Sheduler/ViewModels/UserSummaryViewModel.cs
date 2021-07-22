using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record UserSummaryViewModel(int Id) 
    {
        [JsonProperty("ФИО")] 
        public string Name { get; init; }

        [JsonProperty("Роль")] 
        public string Role { get; init; }
    
        [JsonProperty("Должность")]
        public string Post { get; init; }
    }
}
