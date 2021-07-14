using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sheduler.Model;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.Crud.CreateHandler;
using static Sheduler.RequestHandlers.Crud.UpdateHandler;
using static Sheduler.RequestHandlers.GetAllUsers.GetAllUsersHandler;
using static Sheduler.RequestHandlers.GetBusyDatesHandler;
using static Sheduler.RequestHandlers.GetPostsHandler;
using static Sheduler.RequestHandlers.GetRolesHandler;
using static Sheduler.RequestHandlers.GetUserProfileByIdHandler;

namespace Sheduler.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private IMediator Mediator { get; }

        public UserController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        private async Task<UserProfileViewModel> GetProfileById(int id) => await Mediator.Send(new GetUserProfileByIdQuery(id));

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileViewModel>> GetById(int id)
        {
            var profile = await GetProfileById(id);
            return Ok(profile);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await Mediator.Send(new GetAllUsersQuery());

            return Ok(users);
        }  

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            int id = await Mediator.Send(new CreateCommand(user));

            return CreatedAtAction(nameof(GetById), new {id}, user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> Update(int id, User user)
        {
            await Mediator.Send(new UpdateCommand(id, user));

            return NoContent();
        }

        [HttpPut("self")]
        [Authorize]
        public async Task<ActionResult<User>> Update(SelfChangedProfileViewModel changedProfile)
        {
            int authorizedUserId = Convert.ToInt32(User.Claims
                    .First(claim => claim.Type == "id").Value);
            
           User authorizedUser = (await GetProfileById(authorizedUserId)).User;
            
            authorizedUser.Email = changedProfile.Email;
            authorizedUser.PhoneNumber = changedProfile.PhoneNumber;

            await Mediator.Send(new UpdateCommand(authorizedUserId, authorizedUser));

            return NoContent();
        }

        [HttpGet("post")]
        public async Task<ActionResult<OptionViewModel>> GetPosts()
        {
            var postOptions = await Mediator.Send(new GetPostsQuery());
            return Ok(postOptions);
        }

        [HttpGet("role")]
        public async Task<ActionResult<OptionViewModel>> GetRoles()
        {
            var roleOptions = await Mediator.Send(new GetRolesQuery());

            return Ok(roleOptions);
        }

        [HttpGet("{id}/dates")]
        public async Task<ActionResult<ISet<DateTime>>> GetBusyDates(int id)
        {
            var busyDates = await Mediator.Send(new GetBusyDatesQuery(id));

            return Ok(busyDates);
        }
    }
}
