using AutoMapper;
using Sheduler.Domain.Users.Entities;
using Sheduler.UseCases.Users.Common.Dtos;

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
        }
    }
}
