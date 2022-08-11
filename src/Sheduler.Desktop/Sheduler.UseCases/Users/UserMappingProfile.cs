using AutoMapper;
using Sheduler.Domain.Users.Entities;
using Sheduler.Shared.Dtos.Users;
using Sheduler.UseCases.Users.Common.Dtos;
using Sheduler.UseCases.Users.GetUsers;

namespace Sheduler.UseCases.Users
{
    /// <summary>
    /// User mapping profile.
    /// </summary>
    public class UserMappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserPreviewDto, UserPreviewModel>()
                .ForMember(model => model.Role, mapper => mapper.MapFrom(
                    dto => dto.Role.ToString()));
        }
    }
}
