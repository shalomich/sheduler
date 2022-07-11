using Sheduler.Abstractions;

namespace Sheduler.Implementations;
internal class AuthTokenProvider : IAuthTokenProvider
{
    public string AccessToken { get; set; }

    public bool IsAuthenticated => AccessToken != null;
}

