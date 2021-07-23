﻿using AutoMapper;
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
using static Sheduler.RequestHandlers.GetAllUsers.GetUsersHandler;
using static Sheduler.RequestHandlers.GetApprovingHandler;
using static Sheduler.RequestHandlers.GetBusyDatesHandler;
using static Sheduler.RequestHandlers.GetPostsHandler;
using static Sheduler.RequestHandlers.GetReplacingHandler;
using static Sheduler.RequestHandlers.GetRolesHandler;
using static Sheduler.RequestHandlers.GetUserByIdHandler;
using static Sheduler.RequestHandlers.GetUserProfileHandler;

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
        [Authorize(Roles = "Admin, Manager, Director")]
        public async Task<ActionResult<UserFormViewModel>> Get(int id)
        {
            var user = await Mediator.Send(new GetUserByIdQuery(id));
            return Ok(Mapper.Map<UserFormViewModel>(user));
        }

        private int AuthorizedUserId => Convert.ToInt32(User.Claims
            .First(claim => claim.Type == "id").Value);

        [HttpGet("self")]
        [Authorize]
        public async Task<ActionResult<UserFormViewModel>> Get()
        {
            return await Get(AuthorizedUserId);
        }

        [HttpGet("{id}/profile")]
        [Authorize(Roles = "Admin, Manager, Director")]
        public async Task<ActionResult<UserProfileViewModel>> GetProfile(int id)
        {
            var user = await Mediator.Send(new GetUserByIdQuery(id));

            var profile = await Mediator.Send(new GetUserProfileQuery(user));

            return Ok(profile);
        }

        [HttpGet("self/profile")]
        [Authorize]
        public async Task<ActionResult<UserProfileViewModel>> GetProfile()
        {
            return await GetProfile(AuthorizedUserId);
        }


        [HttpGet]
        [Authorize(Roles = "Admin, Manager, Director")]
        public async Task<ActionResult<IEnumerable<UserSummaryViewModel>>> GetAll()
        {
            var users = await Mediator.Send(new GetUsersQuery(User.IsInRole(UserRole.Manager.ToString())));

            return Ok(users.Select(user => Mapper.Map<UserSummaryViewModel>(user)));
        }  

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> CreateUser(UserFormViewModel formModel)
        {
            User user = Mapper.Map<User>(formModel);

            int id = await Mediator.Send(new CreateCommand(user));

            return CreatedAtAction(nameof(GetProfile), new {id}, user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> Update(int id, UserFormViewModel formModel)
        {
            var user = Mapper.Map<User>(formModel);

            await Mediator.Send(new UpdateCommand(id, user));

            return NoContent();
        }

        [HttpPut("self")]
        [Authorize]
        public async Task<ActionResult<User>> Update(SelfRedactionFormViewModel selfRedactionModel)
        {
            var user = await Mediator.Send(new GetUserByIdQuery(AuthorizedUserId));

            user.Email = selfRedactionModel.Email;
            user.PhoneNumber = selfRedactionModel.PhoneNumber;

            await Mediator.Send(new UpdateCommand(AuthorizedUserId, user));

            return NoContent();
        }

        [HttpGet("post")]
        public async Task<ActionResult<IEnumerable<OptionModel>>> GetPosts()
        {
            var postOptions = await Mediator.Send(new GetPostsQuery());
            return Ok(postOptions);
        }

        [HttpGet("role")]
        public async Task<ActionResult<IEnumerable<OptionModel>>> GetRoles()
        {
            var roleOptions = await Mediator.Send(new GetRolesQuery());

            return Ok(roleOptions);
        }

        [HttpGet("{id}/dates")]
        [Authorize]
        public async Task<ActionResult<ISet<DateTime>>> GetBusyDates(int id)
        {
            var busyDates = await Mediator.Send(new GetBusyDatesQuery(id));

            return Ok(busyDates);
        }

        [HttpGet("approving")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OptionModel>>> GetApprovings()
        {
            var approvings = await Mediator.Send(new GetApprovingQuery(AuthorizedUserId));

            return Ok(approvings);
        }

        [HttpGet("replacing")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OptionModel>>> GetReplacings()
        {
            var replacings = await Mediator.Send(new GetReplacingQuery(AuthorizedUserId));

            return Ok(replacings);
        }

    }
}
