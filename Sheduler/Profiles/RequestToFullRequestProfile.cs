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
            CreateMap<VacationRequest, FullRequestViewModel>()
               .ForMember(view => view.ApprovingName,
                   mapper => mapper.MapFrom(model => model.Approving.Name))
               .ForMember(view => view.Status,
                   mapper => mapper.MapFrom(model => model.Status.ToString()))
               .ForMember(view => view.ReplacingName,
                   mapper => mapper.MapFrom(model => model.Replacing.Name));

            CreateMap<WeekendVacationRequest, FullRequestViewModel>()
               .ForMember(view => view.ApprovingName,
                   mapper => mapper.MapFrom(model => model.Approving.Name))
               .ForMember(view => view.Status,
                   mapper => mapper.MapFrom(model => model.Status.ToString()))
               .ForMember(view => view.ReplacingName,
                   mapper => mapper.MapFrom(model => model.Replacing.Name));

            CreateMap<WeekendWorkOffRequest, FullRequestViewModel>()
               .ForMember(view => view.ApprovingName,
                   mapper => mapper.MapFrom(model => model.Approving.Name))
               .ForMember(view => view.Status,
                   mapper => mapper.MapFrom(model => model.Status.ToString()))
               .ForMember(view => view.ReplacingName,
                   mapper => mapper.MapFrom(model => model.Replacing.Name));

            CreateMap<DayOffRequest, FullRequestViewModel>()
               .ForMember(view => view.ApprovingName,
                   mapper => mapper.MapFrom(model => model.Approving.Name))
               .ForMember(view => view.Status,
                   mapper => mapper.MapFrom(model => model.Status.ToString()))
               .ForMember(view => view.ReplacingName,
                   mapper => mapper.MapFrom(model => model.Replacing.Name));

            CreateMap<RemoteWorkRequest, FullRequestViewModel>()
               .ForMember(view => view.ApprovingName,
                   mapper => mapper.MapFrom(model => model.Approving.Name))
               .ForMember(view => view.Status,
                   mapper => mapper.MapFrom(model => model.Status.ToString()));
        }
    }
}
