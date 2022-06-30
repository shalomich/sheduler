using AutoMapper;
using Sheduler.RestApi.Model.Requests;
using Sheduler.RestApi.ViewModels;
using Sheduler.RestApi.ViewModels.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Profiles
{
    public class FormFullRequestProfile : Profile
    {
        public FormFullRequestProfile()
        {
            CreateMap<RequestFullFormViewModel, VacationRequest>()
                .ReverseMap();
            CreateMap<RequestFullFormViewModel, WeekendVacationRequest>()
                .ReverseMap();
            CreateMap<RequestFullFormViewModel, WeekendWorkOffRequest>()
                .ReverseMap();
            CreateMap<RequestFullFormViewModel, DayOffRequest>()
                .ReverseMap();
            CreateMap<RequestFullFormViewModel, RemoteWorkRequest>()
                .ReverseMap();
        }
    }
}
