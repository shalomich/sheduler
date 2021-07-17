using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sheduler.Attributes;
using Sheduler.Services;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.Form.GetForm.GetFormHandler;

namespace Sheduler.Controllers
{
    [ApiController]
    [Route("/form")]
    public class FormController : Controller
    {
        private IMediator Mediator { get; }

        public FormController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{formModelName}")]
        public async Task<ActionResult<FormTemplateViewModel>> GetForm(string formModelName)
        {
            var form = await Mediator.Send(new GetFormQuery(formModelName));
          
            return new JsonResult(form);
        }
    }
}
