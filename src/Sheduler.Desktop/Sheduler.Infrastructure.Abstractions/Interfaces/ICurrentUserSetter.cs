namespace Sheduler.Infrastructure.Abstractions.Interfaces
{
    /// <summary>
    /// Provides methods for settings the information about current user.
    /// </summary>
    public interface ICurrentUserSetter
    {
        /// <summary>
        /// Set the logged in user id.
        /// </summary>
        /// <param name="userId"></param>
        void SetUserInfo(int userId);

        /// <summary>
        /// Mark current user as logged out.
        /// </summary>
        void Logout();
    }
}
