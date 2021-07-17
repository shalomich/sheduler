using AutoMapper;
using Sheduler.Model;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Profiles
{
    public class UserToUserInfoProfile : Profile
    {
        public UserToUserInfoProfile()
        {
            CreateMap<User, UserSummaryViewModel>()
               .ForMember(view => view.Post,
                   mapper => mapper.MapFrom(model => model.Post.Name));

            CreateMap<User, UserProfileViewModel>()
                .IncludeBase<User, UserSummaryViewModel>();
        }
    }
}
