using AutoMapper;
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
               .ForMember(view => view.ApprovingName,
                   mapper => mapper.MapFrom(model => model.Approving.Name));
            

            CreateMap<RestRequest, FullRequestViewModel>()
                 .ForMember(view => view.ReplacingName,
                     mapper => mapper.MapFrom(model => model.Replacing.Name));

            CreateMap<VacationRequest, FullRequestViewModel>()
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
