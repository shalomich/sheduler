using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sheduler.MVVM.ViewModels.Auth.Login;
public class LoginModel : ObservableObject
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
