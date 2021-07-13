using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sheduler.Attributes;
using Sheduler.RequestHandlers.Form.GetBuildingData;
using Sheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Controllers
{
    [ApiController]
    [Route("/form/[controller]")]
    [GenericControllerName]
    public class FormController<T> : Controller
    {
        private IMediator Mediator { get; }

        public FormController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> GetForm()
        {
            var form = await Mediator.Send(new GetFormQuery { ModelType = typeof(T)});
          
            return new JsonResult(form);
        }
    }
}
