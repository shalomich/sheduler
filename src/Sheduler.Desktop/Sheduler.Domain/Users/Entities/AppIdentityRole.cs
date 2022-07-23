using Microsoft.AspNetCore.Identity;

namespace Sheduler.Domain.Users.Entities
{
    /// <summary>
    /// Custom application identity role.
    /// </summary>
    public class AppIdentityRole : IdentityRole<int>
    {
    }
}
