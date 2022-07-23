using AutoMapper;
using Sheduler.RestApi.ViewModels.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Profiles
{
    public class RequestFormToFullFormProfile : Profile
    {
        public RequestFormToFullFormProfile()
        {
            CreateMap<VacationRequestFormViewModel, RequestFullFormViewModel>();
            CreateMap<WeekendVacationRequestViewModel, RequestFullFormViewModel>();
            CreateMap<WeekendWorkOffRequestFormViewModel, RequestFullFormViewModel>();
            CreateMap<DayOffRequestFormViewModel, RequestFullFormViewModel>();
            CreateMap<RemoteWorkRequestFormViewModel, RequestFullFormViewModel>();
        }
    }
}
