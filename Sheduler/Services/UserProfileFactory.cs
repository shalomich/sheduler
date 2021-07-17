using AutoMapper;
using Sheduler.Model;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Services
{
    public class UserProfileFactory
    {
        private ApplicationContext Context { get; }

        private IMapper Mapper { get; }

        public UserProfileFactory(ApplicationContext context, IMapper mapper)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public UserProfileViewModel Create(User user)
        {
            return Mapper.Map<UserProfileViewModel>(user);
        }
    }
}
