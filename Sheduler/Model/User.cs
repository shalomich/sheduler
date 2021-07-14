using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using Sheduler.Attributes;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sheduler.Model
{
    [FormModel]
    public class User : IEntity
    {
        public User(string email, string password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public int Id { set; get; }
        
        [FormField(FormFieldType.Email)]
        [EmailAddress]
        [Required]
        public string Email { set; get; }

        [FormField(FormFieldType.Password)]
        [Required]
        public string Password { set; get; }
        
        [FormField(FormFieldType.Text, false)]
        [RegularExpression("^[А-ЯЁ][а-яё]* [А-ЯЁ][а-яё]* [А-ЯЁ][а-яё]*$")]
        public string Name { set; get; }

        [FormField(FormFieldType.Select, false)]
        public UserRole Role { set; get; } = UserRole.Employee;
        
        [FormField(FormFieldType.Select, false)]
        public Post Post {private set; get; }
        public int? PostId { set; get; }

        [FormField(FormFieldType.Tel, false)]
        [RegularExpression(@"8-9\d{2}-\d{3}-\d{2}-\d{2}")]
        public string PhoneNumber { set; get; }
        public DateTime AccountCreatingDate { private set; get; } = DateTime.Now.Date;
        public ISet<Request> Requests {set; get; }
       
    }

    
}
