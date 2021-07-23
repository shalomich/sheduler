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
    public class RequestToProfileProfile : Profile
    {
        public RequestToProfileProfile()
        {
            CreateMap<Request, RequestProfileViewModel>()
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
            

            CreateMap<RestRequest, RequestProfileViewModel>()
                 .ForMember(view => view.ReplacingName,
                     mapper => mapper.MapFrom(model => model.Replacing.Name));

            CreateMap<VacationRequest, RequestProfileViewModel>()
                .ForMember(view => view.VacationType,
                    mapper => mapper.MapFrom(model => model.VacationType.ToString()))
                .IncludeBase<RestRequest, RequestProfileViewModel>();
            
            CreateMap<WeekendVacationRequest, RequestProfileViewModel>()
                .IncludeBase<RestRequest, RequestProfileViewModel>();
            CreateMap<WeekendWorkOffRequest, RequestProfileViewModel>()
                .IncludeBase<RestRequest, RequestProfileViewModel>();
            CreateMap<DayOffRequest, RequestProfileViewModel>()
                .IncludeBase<RestRequest, RequestProfileViewModel>();
            CreateMap<RemoteWorkRequest, RequestProfileViewModel>()
                .IncludeBase<Request, RequestProfileViewModel>();

        }
    }
}
