using Sheduler.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Sheduler.ViewModels
{
    [FormModel]
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [FormField(FormFieldType.Email)]
        public string Email { set; get; }

        [Required]
        [FormField(FormFieldType.Password)]
        public string Password { set; get; }

        public void Deconstruct(out string email, out string password)
        {
            email = Email;
            password = Password;
        }
    }
}
