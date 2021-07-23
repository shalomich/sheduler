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
            CreateMap<User, UserTableViewModel>()
               .ForMember(view => view.Post,
                   mapper => mapper.MapFrom(model => model.Post.Name))
               .ForMember(view => view.Role,
                   mapper => mapper.MapFrom(model => model.Role.ToString()));

            CreateMap<User, UserProfileViewModel>()
               .ForMember(view => view.Post,
                       mapper => mapper.MapFrom(model => model.Post.Name))
                .ForMember(view => view.Role,
                    mapper => mapper.MapFrom(model => model.Role.ToString()));
        }
    }
}
