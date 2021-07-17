using AutoMapper;
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
                    mapper => mapper.MapFrom(model => model.Approving.Name));
        }
    }
}
