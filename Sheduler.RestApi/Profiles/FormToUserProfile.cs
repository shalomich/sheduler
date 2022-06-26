using AutoMapper;
using Sheduler.RestApi.Model;
using Sheduler.RestApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Profiles
{
    public class FormToUserProfile : Profile
    {
        public FormToUserProfile()
        {
            CreateMap<UserFormViewModel, User>().ReverseMap();
        }
    }
}
