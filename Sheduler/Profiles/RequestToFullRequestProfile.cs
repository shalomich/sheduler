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
    public class RequestToFullRequestProfile : Profile
    {
        public RequestToFullRequestProfile()
        {
            CreateMap<Request, FullRequestViewModel>()
                .ForMember(view => view.ChoosendDates,
                    mapper => mapper.MapFrom(model => model.ChoosendDates
                    .Select(date => date.ToDateString())
                    .Aggregate((date1, date2) => $"{date1}, {date2}")))
                .ForMember(view => view.CreationDate,
                    mapper => mapper.MapFrom(model => model.CreationDate.ToDateString()))
               .ForMember(view => view.ApprovingName,
                   mapper => mapper.MapFrom(model => model.Approving.Name))
               .ForMember(view => view.Status,
                   mapper => mapper.MapFrom(model => model.Status.ToString().ToLower()));
            

            CreateMap<RestRequest, FullRequestViewModel>()
                 .ForMember(view => view.ReplacingName,
                     mapper => mapper.MapFrom(model => model.Replacing.Name));

            CreateMap<VacationRequest, FullRequestViewModel>()
                .ForMember(view => view.VacationType,
                    mapper => mapper.MapFrom(model => model.VacationType.ToString()))
                .IncludeBase<RestRequest, FullRequestViewModel>();
            
            CreateMap<WeekendVacationRequest, FullRequestViewModel>()
                .IncludeBase<RestRequest, FullRequestViewModel>();
            CreateMap<WeekendWorkOffRequest, FullRequestViewModel>()
                .IncludeBase<RestRequest, FullRequestViewModel>();
            CreateMap<DayOffRequest, FullRequestViewModel>()
                .IncludeBase<RestRequest, FullRequestViewModel>();
            CreateMap<RemoteWorkRequest, FullRequestViewModel>()
                .IncludeBase<Request, FullRequestViewModel>();

        }
    }
}
