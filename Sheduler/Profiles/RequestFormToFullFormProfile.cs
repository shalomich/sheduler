using AutoMapper;
using Sheduler.ViewModels.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Profiles
{
    public class RequestFormToFullFormProfile : Profile
    {
        public RequestFormToFullFormProfile()
        {
            CreateMap<VacationRequestFormViewModel, FullRequestFormViewModel>();
            CreateMap<WeekendVacationRequestViewModel, FullRequestFormViewModel>();
            CreateMap<WeekendWorkOffRequestFormViewModel, FullRequestFormViewModel>();
            CreateMap<DayOffRequestFormViewModel, FullRequestFormViewModel>();
            CreateMap<RemoteWorkRequestFormViewModel, FullRequestFormViewModel>();
        }
    }
}
