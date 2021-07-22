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
            CreateMap<FullRequestFormViewModel, VacationRequest>()
                .ReverseMap();
            CreateMap<FullRequestFormViewModel, WeekendVacationRequest>()
                .ReverseMap();
            CreateMap<FullRequestFormViewModel, WeekendWorkOffRequest>()
                .ReverseMap();
            CreateMap<FullRequestFormViewModel, DayOffRequest>()
                .ReverseMap();
            CreateMap<FullRequestFormViewModel, RemoteWorkRequest>()
                .ReverseMap();
        }
    }
}
