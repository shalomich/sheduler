using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Sheduler.Domain.Users.Entities
{
    /// <summary>
    /// Custom application user entity.
    /// </summary>
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// Admin user id.
        /// </summary>
        public const int AdminUserId = 1;

        /// <summary>
        /// First name.
        /// </summary>
        [MaxLength(255)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        [MaxLength(255)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Full name, concat of first name and last name.
        /// </summary>
        public string FullName => Saritasa.Tools.Common.Utils.StringUtils.JoinIgnoreEmpty(FirstName, LastName);

        /// <summary>
        /// The date when user last logged in.
        /// </summary>
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Last token reset date. Before the date all generate login tokens are considered
        /// not valid. Must be in UTC format.
        /// </summary>
        public DateTime LastTokenResetAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Is user administrator.
        /// </summary>
        public bool IsAdmin => Id == AdminUserId;

        /// <summary>
        /// Clean entity state.
        /// </summary>
        public void Clean()
        {
            FirstName = Saritasa.Tools.Common.Utils.StringUtils.NullSafe(FirstName).Trim();
            LastName = Saritasa.Tools.Common.Utils.StringUtils.NullSafe(LastName).Trim();
            Email = Saritasa.Tools.Common.Utils.StringUtils.NullSafe(Email).Trim().ToLower();
            UserName = Saritasa.Tools.Common.Utils.StringUtils.NullSafe(UserName).Trim().ToLower();
        }
    }
}
