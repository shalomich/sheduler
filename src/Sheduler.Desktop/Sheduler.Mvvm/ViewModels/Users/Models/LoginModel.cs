using System.ComponentModel.DataAnnotations;
using Sheduler.Mvvm.Utils;

namespace Sheduler.Mvvm.ViewModels.Users.Models
{
    /// <summary>
    /// Login model.
    /// </summary>
    public class LoginModel : EditableModel
    {
        /// <summary>
        /// User name.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
