using MediatR;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Sheduler.UseCases.Auth.Login;
using Sodium.XRayImage.Mvvm.Utils.Commands;
using System.Threading.Tasks;

namespace Sheduler.MVVM.ViewModels.Auth.Login;
public class LoginViewModel : ObservableObject
{
    private readonly IMediator mediator;

    public LoginModel LoginModel { get;} 
    public AsyncCommand LoginUICommand { get; }

    public LoginViewModel(
        IMediator mediator)
    {
        this.mediator = mediator;

        LoginModel = new();
        LoginUICommand = new AsyncCommand(LoginAsync);
    }

    private async Task LoginAsync()
    {
        await mediator.Send(new LoginCommand(LoginModel.Email, LoginModel.Password));
    }
}

