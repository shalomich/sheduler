using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Sheduler.Domain.Users.Entities;
using Sheduler.Infrastructure.Abstractions.Interfaces;
using Saritasa.Tools.Domain.Exceptions;

namespace Sheduler.UseCases.Users.LoginUser
{
    /// <summary>
    /// Handler for <see cref="LoginUserCommand" />.
    /// </summary>
    internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResult>
    {
        private const string InvalidCredentialsErrorMessage = "Email or password is incorrect.";

        private readonly SignInManager<User> signInManager;
        private readonly ILogger<LoginUserCommandHandler> logger;
        private readonly ICurrentUserSetter currentUserSetter;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="signInManager">Sign in manager.</param>
        /// <param name="tokenService">Token service.</param>
        /// <param name="logger">Logger.</param>
        public LoginUserCommandHandler(
            SignInManager<User> signInManager,
            ILogger<LoginUserCommandHandler> logger,
            ICurrentUserSetter currentUserSetter)
        {
            this.signInManager = signInManager;
            this.logger = logger;
            this.currentUserSetter = currentUserSetter;
        }

        /// <inheritdoc />
        public async Task<LoginUserCommandResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await signInManager.UserManager.FindByEmailAsync(request.Email)
                .ConfigureAwait(false);
            if (user is null)
            {
                throw new ValidationException(InvalidCredentialsErrorMessage);
            }

            var signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
            ValidateSignInResult(signInResult, request.Email);
            logger.LogInformation("User with email {email} has logged in.", user.Email);

            // Update last login date.
            user.LastLogin = DateTime.UtcNow;
            await signInManager.UserManager.UpdateAsync(user);

            currentUserSetter.SetUserInfo(user.Id);

            return new LoginUserCommandResult
            {
                UserId = user.Id,
            };
        }

        private void ValidateSignInResult(SignInResult signInResult, string email)
        {
            if (!signInResult.Succeeded)
            {
                if (signInResult.IsNotAllowed)
                {
                    throw new DomainException($"User {email} is not allowed to Sign In.");
                }
                if (signInResult.IsLockedOut)
                {
                    throw new DomainException($"User {email} is locked out.");
                }
                throw new ValidationException(InvalidCredentialsErrorMessage);
            }
        }
    }
}
