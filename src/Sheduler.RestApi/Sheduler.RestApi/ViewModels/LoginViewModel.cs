using Sheduler.RestApi.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.ViewModels
{
    [FormModel("login")]
    public record LoginViewModel
    {
        [Required]
        [EmailAddress]
        [FormField(FormFieldType.Email)]
        public string Email { set; get; }

        [Required]
        [FormField(FormFieldType.Password, "Пароль")]
        public string Password { set; get; }

        public void Deconstruct(out string email, out string password)
        {
            email = Email;
            password = Password;
        }
    }
}
