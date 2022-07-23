using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sheduler.RestApi.Middlewares.ExceptionHandler;
using Sheduler.RestApi.Model;
using Sheduler.RestApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.Auth.LoginHandler;

namespace Sheduler.RestApi.RequestHandlers.Auth
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        public record LoginCommand(LoginViewModel LoginModel) : IRequest<string>;

        private const string WrongEmailMessage = "Email does not exist";
        private const string WrongPasswordMessage = "Password is uncorrect";
        private ApplicationContext Context { get; }
        private AuthOptions Options { get; }

        public LoginHandler(ApplicationContext context, IOptions<AuthOptions> options)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            
            var (email, password) = request.LoginModel;

            User user = await Context.Users
                    .SingleOrDefaultAsync(user => user.Email == email);
             
            if (user == null) 
                throw new RestException(WrongEmailMessage, HttpStatusCode.NotFound);
            

            if (user.Password != password)
                throw new RestException(WrongPasswordMessage, HttpStatusCode.BadRequest);
      
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("role", user.Role.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: Options.Issuer,
                    audience: Options.Audience,
                    notBefore: DateTime.UtcNow,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(Options.Lifetime)),
                    signingCredentials: new SigningCredentials(Options.GenerateSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
