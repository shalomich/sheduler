using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.ViewModels
{
    public record SelfChangedProfileViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { init; get; }

        [Required]
        [Phone]
        [RegularExpression(@"8-9\d{2}-\d{3}-\d{2}-\d{2}")]
        public string PhoneNumber { init; get; }
    }
}
