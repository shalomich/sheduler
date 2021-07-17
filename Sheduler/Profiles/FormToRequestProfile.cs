using AutoMapper;
using Sheduler.Model.Requests;
using Sheduler.ViewModels;
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
            CreateMap<RequestFormViewModel, VacationRequest>();
            CreateMap<RequestFormViewModel, WeekendVacationRequest>();
            CreateMap<RequestFormViewModel, WeekendWorkOffRequest>();
            CreateMap<RequestFormViewModel, DayOffRequest>();
            CreateMap<RequestFormViewModel, RemoteWorkRequest>();
        }
    }
}
