using AutoMapper;
using Sheduler.Model;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Profiles
{
    public class SelfRedactionFormToUserFormProfile : Profile
    {
        public SelfRedactionFormToUserFormProfile()
        {
            CreateMap<SelfRedactionFormViewModel, UserFormViewModel>();
        }
    }
}
