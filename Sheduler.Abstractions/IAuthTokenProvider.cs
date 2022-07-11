namespace Sheduler.Abstractions;
public interface IAuthTokenProvider
{
    public string AccessToken { get; set; }
    public bool IsAuthenticated { get; }
}

