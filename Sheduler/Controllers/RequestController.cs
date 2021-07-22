using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sheduler.Extensions;
using Sheduler.Model;
using Sheduler.Model.Requests;
using Sheduler.RequestHandlers;
using Sheduler.RequestHandlers.Crud.GetById;
using Sheduler.ViewModels;
using Sheduler.ViewModels.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.ChangeStatusHandler;
using static Sheduler.RequestHandlers.CheckRequestDatesValidityHandler;
using static Sheduler.RequestHandlers.Crud.CreateHandler;
using static Sheduler.RequestHandlers.Crud.UpdateHandler;
using static Sheduler.RequestHandlers.GetAllRequestHandler;
using static Sheduler.RequestHandlers.GetRequestByIdHandler;
using static Sheduler.RequestHandlers.GetStatusesHandler;
using static Sheduler.RequestHandlers.GetVacationTypesHandler;

namespace Sheduler.Controllers
{
    [ApiController]
    [Route("request")]
    public class RequestController : Controller
    {
        private IMediator Mediator { get; }
        private IMapper Mapper { get; }

        public RequestController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private int UserId => Convert.ToInt32(User.Claims
            .Single(claim => claim.Type == "id").Value);

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CommonRequestViewModel>>> GetAll()
        {
            var requests = await Mediator.Send(new GetAllRequestQuery(UserId, User.IsInRole(UserRole.Employee.ToString())));

            var requestViews = requests.Select(request => Mapper.Map<CommonRequestViewModel>(request));

            return Ok(requestViews);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<FullRequestFormViewModel>> GetById(int id)
        {
            Request requestById = await Mediator.Send(new GetRequestByIdQuery(id));

            var fullRequest = Mapper.Map<FullRequestFormViewModel>(requestById);
            
            return Ok(fullRequest);
        }

        [HttpGet("{id}/profile")]
        public async Task<ActionResult<FullRequestViewModel>> GetRequestProfileById(int id)
        {
            Request requestById = await Mediator.Send(new GetRequestByIdQuery(id));

            var requestProfile = Mapper.Map(requestById, requestById.GetType(), typeof(FullRequestViewModel));

            return Ok(requestProfile);
        }

        [HttpGet("{id}/type")]
        public async Task<ActionResult<string>> GetRequestType(int id)
        {
            Request requestById = await Mediator.Send(new GetRequestByIdQuery(id));
           
            return Ok(requestById.GetType().Name.ToString().FirstCharToLowerCase());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Request>> Create([FromQuery] string type, [FromBody]FullRequestFormViewModel fullRequestModel)
        {
            Request request = Mapper.MapRequestFromForm(type, fullRequestModel);

            request.CreatorId = UserId;

            await Mediator.Send(new CheckRequestDatesValidityCommand(request));

            int id = await Mediator.Send(new CreateCommand(request));

            return Created("", request);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<Request>> Update([FromQuery] string type, [FromRoute] int id, [FromBody] FullRequestFormViewModel fullRequestModel)
        {
            Request request = Mapper.MapRequestFromForm(type, fullRequestModel);

            request.CreatorId = UserId;

            await Mediator.Send(new CheckRequestDatesValidityCommand(request));

            await Mediator.Send(new UpdateCommand(id, request));

            return NoContent();
        }


        private async Task<IActionResult> ChangeRequestStatus(int id, RequestStatus status)
        {
            Request request = (Request)await Mediator.Send(new GetByIdQuery(id, typeof(Request)));

            await Mediator.Send(new ChangeStatusCommand(request, status));

            return NoContent();
        }

        [HttpPut("{id}/sent")]
        public async Task<IActionResult> Sent(int id) => await ChangeRequestStatus(id, RequestStatus.Sent);

        [HttpPut("{id}/approved")]
        public async Task<IActionResult> Approve(int id) => await ChangeRequestStatus(id, RequestStatus.Approved);

        [HttpPut("{id}/disapproved")]
        public async Task<IActionResult> Disapprove(int id) => await ChangeRequestStatus(id, RequestStatus.Disapproved);

        [HttpPut("{id}/allowed")]
        public async Task<IActionResult> Allow(int id) => await ChangeRequestStatus(id, RequestStatus.Allowed);

        [HttpPut("{id}/disallowed")]
        public async Task<IActionResult> Disallow(int id) => await ChangeRequestStatus(id, RequestStatus.Disallowed);

        [HttpPut("{id}/withdrawn")]
        public async Task<IActionResult> Withdraw(int id) => await ChangeRequestStatus(id, RequestStatus.Withdrawn);

        [HttpPut("{id}/cancelled")]
        public async Task<IActionResult> Cancel(int id) => await ChangeRequestStatus(id, RequestStatus.Cancelled);


        [HttpGet("status")]
        public async Task<ActionResult<IEnumerable<OptionModel>>> GetStatuses()
        {
            var statusOptions  = await Mediator.Send(new GetStatusesQuery());

            return Ok(statusOptions);
        }

        [HttpGet("vacationType")]
        public async Task<ActionResult<IEnumerable<OptionModel>>> GetVacationTypes()
        {
            var vacationTypeOptions = await Mediator.Send(new GetVacationTypesQuery());

            return Ok(vacationTypeOptions);
        }
    }
}
