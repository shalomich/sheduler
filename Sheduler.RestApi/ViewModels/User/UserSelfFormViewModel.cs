using Sheduler.RestApi.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.ViewModels
{
    [FormModel("self")]
    public record UserSelfFormViewModel
    {
        [Required]
        [EmailAddress]
        [FormField(FormFieldType.Email)]
        public string Email { init; get; }

        [Required]
        [Phone]
        [RegularExpression(@"89\d{9}")]
        [FormField(FormFieldType.Tel, "Номер телефона")]
        public string PhoneNumber { init; get; }
    }
}
