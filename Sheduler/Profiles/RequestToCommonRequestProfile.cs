using AutoMapper;
using Sheduler.Extensions;
using Sheduler.Model.Requests;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Profiles
{
    public class RequestToCommonRequestProfile : Profile
    {
        public RequestToCommonRequestProfile()
        {
            CreateMap<Request, CommonRequestViewModel>()
                .ForMember(view => view.CreatorName,
                    mapper => mapper.MapFrom(model => model.Creator.Name))
                .ForMember(view => view.ApprovingName,
                    mapper => mapper.MapFrom(model => model.Approving.Name))
                .ForMember(view => view.Status,
                    mapper => mapper.MapFrom(model => model.Status.ToString()))
                .ForMember(view => view.ChoosendDates,
                    mapper => mapper.MapFrom(model => model.ChoosendDates
                        .Select(date => date.ToDateString())
                        .Aggregate((date1, date2) => $"{date1}, {date2}")))
                .ForMember(view => view.SendingDate,
                    mapper => mapper.MapFrom(model => model.SendingDate.Value.ToDateString()));
        }
    }
}
