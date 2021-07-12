using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Model
{
    public class User
    {
        public User(string email, string password)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public int Id { private set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
        public UserRole Role { set; get; } = UserRole.Employee;
        public Post Post { set; get; }
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
