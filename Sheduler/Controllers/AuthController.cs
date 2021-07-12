using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sheduler.Model;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.Auth.LoginHandler;

namespace Sheduler.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private IMediator Mediator { get; }

        public AuthController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            string token = await Mediator.Send(new LoginCommand(loginModel));

            return new JsonResult(token);    
        }
    }
    
}
