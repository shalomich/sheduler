using Sheduler.Attributes;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model
{
    [FormModel]
    public class User
    {
        public User(string email, string password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public int Id { private set; get; }
        
        [FormField(FormFieldType.Email)]
        public string Email { set; get; }

        [FormField(FormFieldType.Password)]
        public string Password { set; get; }
        
        [FormField(FormFieldType.Text, false)]
        public string Name { set; get; }

        [FormField(FormFieldType.Select, false)]
        public UserRole Role { set; get; } = UserRole.Employee;
        
        [FormField(FormFieldType.Select, false)]
        public Post Post { set; get; }

        [FormField(FormFieldType.Tel, false)]
        public string PhoneNumber { set; get; }
        public DateTime AccountCreatingDate { private set; get; } = DateTime.Now;
        public ISet<Request> Requests {set; get; }
       
    }
    public enum UserRole
    {
        Employee,
        Admin,
        Manager,
        Director
    }
}
