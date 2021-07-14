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

        public UserProfileFactory(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public UserProfileViewModel Create(User user)
        {
            var profile = new UserProfileViewModel(user);


            return profile;
        }
    }
}
