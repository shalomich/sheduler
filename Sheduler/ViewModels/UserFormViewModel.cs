using Sheduler.Attributes;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    [FormModel("User")]
    public class UserFormViewModel
    {       
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
        public UserRole? Role { set; get; }

        [FormField(FormFieldType.Select, false)]
        public int? PostId { set; get; }

        [FormField(FormFieldType.Tel, false)]
        [RegularExpression(@"8-9\d{2}-\d{3}-\d{2}-\d{2}")]
        public string PhoneNumber { set; get; }
    }

}