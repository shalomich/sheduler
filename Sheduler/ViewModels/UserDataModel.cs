using Newtonsoft.Json;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record UserDataModel(int Id) : UserSummaryViewModel(Id)
    {
        public string Email { get; init; }

        [JsonProperty("Номер телефона")]
        public string PhoneNumber { get; init; }
    }
       
}
