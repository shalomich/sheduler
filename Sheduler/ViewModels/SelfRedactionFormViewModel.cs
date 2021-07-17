using Sheduler.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    [FormModel("self")]
    public record SelfRedactionFormViewModel
    {
        [Required]
        [EmailAddress]
        [FormField(FormFieldType.Email)]
        public string Email { init; get; }

        [Required]
        [Phone]
        [RegularExpression(@"8-9\d{2}-\d{3}-\d{2}-\d{2}")]
        [FormField(FormFieldType.Password)]
        public string PhoneNumber { init; get; }
    }
}
