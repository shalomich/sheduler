using AutoMapper;
using Sheduler.Model.Requests;
using Sheduler.ViewModels;
using Sheduler.ViewModels.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Profiles
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
