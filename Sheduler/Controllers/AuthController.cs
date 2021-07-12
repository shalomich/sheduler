using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sheduler.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private ApplicationContext Context { get; }
        private AuthOptions Options { get; }

        public AuthController(ApplicationContext context, IOptions<AuthOptions> options)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] string email,[FromBody] string password)
        {
            var identity = GetIdentity(email, password);
            if (identity == null)
            {
                return BadRequest();
            }


            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: Options.Issuer,
                    audience: Options.Audience,
                    notBefore: DateTime.UtcNow,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(Options.Lifetime)),
                    signingCredentials: new SigningCredentials(Options.GenerateSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            return Json(encodedJwt);
        }
 
        private ClaimsIdentity GetIdentity(string email, string password)
        {
            try
            {
                User user = Context.Users
                    .Single(user => user.Email == email && user.Password == password);
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token",
                    ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                
                return claimsIdentity;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
    
}
