namespace Sheduler.Infrastructure.Abstractions.Interfaces
{
    public interface IAuthenticationTokenStorage
    {
        string AccessToken { get; }
    }
}
