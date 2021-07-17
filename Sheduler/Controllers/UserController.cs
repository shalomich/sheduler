using AutoMapper;
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
using static Sheduler.RequestHandlers.GetAllUsers.GetUserSummariesHandler;
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
        private IMapper Mapper { get; }

        public UserController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileViewModel>> Get(int id)
        {
            var profile = await Mediator.Send(new GetUserProfileByIdQuery(id));
            return Ok(profile);
        }

        [HttpGet("self")]
        [Authorize]
        public async Task<ActionResult<UserProfileViewModel>> Get()
        {
            int authorizedUserId = Convert.ToInt32(User.Claims
                    .First(claim => claim.Type == "id").Value);

            return await Get(authorizedUserId);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSummaryViewModel>>> GetAll()
        {
            var userSummaries = await Mediator.Send(new GetUserSummariesQuery());

            return Ok(userSummaries);
        }  

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(UserFormViewModel formModel)
        {
            User user = Mapper.Map<User>(formModel);

            int id = await Mediator.Send(new CreateCommand(user));

            return CreatedAtAction(nameof(Get), new {id}, user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> Update(int id, UserFormViewModel formModel)
        {
            User user = Mapper.Map<User>(formModel);

            await Mediator.Send(new UpdateCommand(id, user));

            return NoContent();
        }

        [HttpPut("self")]
        [Authorize]
        public async Task<ActionResult<User>> Update(SelfRedactionFormViewModel selfRedactionModel)
        {
            int authorizedUserId = Convert.ToInt32(User.Claims
                    .First(claim => claim.Type == "id").Value);

            UserFormViewModel formModel = Mapper.Map<UserFormViewModel>(selfRedactionModel);

            return await Update(authorizedUserId, formModel);
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
