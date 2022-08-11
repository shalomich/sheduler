using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using Sheduler.RestApi.Attributes;
using Sheduler.RestApi.Model.Requests;
using Sheduler.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Model
{

    public class User : IEntity
    {
        public User(string email, string password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public int Id { set; get; } 
        public string Email { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
        public UserRole Role { set; get; } = UserRole.Employee;
        public Post Post {private set; get; }
        public int? PostId { set; get; }
        public string PhoneNumber { set; get; }
        public DateTime AccountCreatingDate { private set; get; } = DateTime.Now.Date;
        public ISet<Request> Requests {set; get; }
       
    }

    
}
