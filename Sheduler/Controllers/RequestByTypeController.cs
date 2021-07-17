using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sheduler.Attributes;
using Sheduler.Attributes.GenericController;
using Sheduler.Model;
using Sheduler.Model.Requests;
using Sheduler.RequestHandlers.Crud.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.Crud.CreateHandler;
using static Sheduler.RequestHandlers.Crud.UpdateHandler;
using static Sheduler.RequestHandlers.RequestByType.GetRequestByIdHandler;

namespace Sheduler.Controllers
{
    [ApiController]
    [Route("requestByType/[controller]")]
    [GenericController(typeof(RequestStrategy))]
    public class RequestByTypeController<T> : Controller where T : Request
    {
        private IMediator Mediator { get; }
        public RequestByTypeController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetById(int id)
        {
            T request = await Mediator.Send(new GetRequestByIdQuery(id)) as T;

            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult<T>> Create(T request)
        {
            int id = await Mediator.Send(new CreateCommand(request));

            return CreatedAtAction(nameof(GetById), new { id }, request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Update(int id, T request)
        {
            await Mediator.Send(new UpdateCommand(id, request));

            return NoContent();
        }
    }
}
