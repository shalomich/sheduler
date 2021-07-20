using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record UserDataModel(int Id, string Name, string Role,string Post,
        string Email, string PhoneNumber) : UserSummaryViewModel(Id,Name,Role,Post);
}
