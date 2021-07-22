using Newtonsoft.Json;
using Sheduler.Model.Requests;
using Sheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public class CommonRequestViewModel
    {
        public int Id { set; get; }
        
        [JsonProperty("Заявитель")]
        public string CreatorName { set; get; }

        [JsonProperty("Тип заявки")]
        public string Type { set; get; }

        [JsonProperty("Дата отправки")]
        public string SendingDate { set; get; }

        [JsonProperty("Выбранные даты")]
        public string ChoosendDates { set; get; }
        
        [JsonProperty("Количество дней")]
        public int? DayQuantity { set; get; }
        
        [JsonProperty("Согласующий")]
        public string ApprovingName { set; get; }

        [JsonProperty("Статус")]
        public string Status { set; get; }
    }
}
