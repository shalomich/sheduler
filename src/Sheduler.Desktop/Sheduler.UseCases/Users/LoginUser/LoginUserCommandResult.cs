namespace Sheduler.UseCases.Users.LoginUser
{
    /// <summary>
    /// Represents user login attempt to system.
    /// </summary>
    public class LoginUserCommandResult
    {
        /// <summary>
        /// Logged user id (if success).
        /// </summary>
        public int UserId { get; set; }
    }
}
