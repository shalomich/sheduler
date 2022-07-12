using MediatR;
using RestSharp;
using Sheduler.Abstractions;
using Sheduler.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Sheduler.UseCases.Auth.Login;

public record LoginCommand(string Email, string Password) : IRequest;
internal class LoginCommandHandler : AsyncRequestHandler<LoginCommand>
{
    private readonly IAuthTokenProvider authTokenProvider;
    private readonly RestClient restClient;

    public LoginCommandHandler(
        IAuthTokenProvider authTokenProvider,
        RestClient restClient)
    {
        this.authTokenProvider = authTokenProvider;
        this.restClient = restClient;
    }

    protected override async Task Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var loginDto = new LoginDto
        {
            Email = request.Email,
            Password = request.Password,
        };

        var restRequest = new RestRequest("", Method.Post)
            .AddBody(loginDto);

        var response = await restClient.ExecuteAsync<string>(restRequest, cancellationToken);

        authTokenProvider.AccessToken = response.Content;
    }
}

