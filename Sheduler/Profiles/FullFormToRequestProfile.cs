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
            CreateMap<FullRequestFormViewModel, VacationRequest>();
            CreateMap<FullRequestFormViewModel, WeekendVacationRequest>();
            CreateMap<FullRequestFormViewModel, WeekendWorkOffRequest>();
            CreateMap<FullRequestFormViewModel, DayOffRequest>();
            CreateMap<FullRequestFormViewModel, RemoteWorkRequest>();
        }
    }
}
