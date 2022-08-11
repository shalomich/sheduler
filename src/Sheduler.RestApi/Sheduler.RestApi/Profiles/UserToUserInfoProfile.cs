﻿using AutoMapper;
using Sheduler.RestApi.Model;
using Sheduler.RestApi.ViewModels;
using Sheduler.Shared.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Profiles
{
    public class UserToUserInfoProfile : Profile
    {
        public UserToUserInfoProfile()
        {
            CreateMap<User, UserPreviewDto>()
               .ForMember(view => view.Post,
                   mapper => mapper.MapFrom(model => model.Post.Name))
               .ForMember(view => view.Role,
                   mapper => mapper.MapFrom(model => model.Role));

            CreateMap<User, UserProfileViewModel>()
               .ForMember(view => view.Post,
                       mapper => mapper.MapFrom(model => model.Post.Name))
                .ForMember(view => view.Role,
                    mapper => mapper.MapFrom(model => model.Role.ToString()));
        }
    }
}
