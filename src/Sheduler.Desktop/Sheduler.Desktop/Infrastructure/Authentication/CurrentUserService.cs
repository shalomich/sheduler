using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sheduler.Infrastructure.Abstractions.Interfaces;

namespace Sheduler.Desktop.Infrastructure.Authentication
{
    /// <summary>
    /// Manages access to current user data.
    /// </summary>
    public class CurrentUserService : ICurrentUserAccessor, ICurrentUserSetter
    {
        private bool isAuthenticated = false;
        private int currentUserId;

        /// <inheritdoc />
        public int GetCurrentUserId()
        {
            return currentUserId;
        }

        /// <inheritdoc />
        public bool IsAuthenticated()
        {
            return isAuthenticated;
        }

        /// <inheritdoc />
        public void Logout()
        {
            isAuthenticated = false;
            currentUserId = default;
        }

        /// <inheritdoc />
        public void SetUserInfo(int userId)
        {
            currentUserId = userId;
            isAuthenticated = true;
        }
    }
}
