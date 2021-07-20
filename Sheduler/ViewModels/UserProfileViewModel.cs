using Sheduler.Extensions;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record UserProfileViewModel(UserDataModel Data, UserStatisticsModel Statistics);
}
