using Newtonsoft.Json;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public class RequestProfileViewModel
    {
        public int Id { set; get; }

        [JsonProperty("Тип заявки")]
        public string Type { set; get; }

        public string Status { set; get; }

        [JsonProperty("Выбранные даты")]
        public ISet<DateTime> ChoosendDates { set; get; }

        [JsonProperty("Дата создания")]
        public string CreationDate { set; get; }

        [JsonProperty("Согласующий")]
        public string ApprovingName { set; get; }

        [JsonProperty("Комментарий")]
        public string Comment { set; get; }

        [JsonProperty("Замещающий")]
        public string ReplacingName { set; get; }
        public int CreatorId { set; get; }

        [JsonProperty("Рабочий план")]
        public string WorkingPlan { set; get; }

        [JsonProperty("Тип отпуска")]
        public string VacationType { set; get; }

        [JsonProperty("Даты отработки")]
        public ISet<DateTime> WorkOffDates { set; get; }
    }
}
