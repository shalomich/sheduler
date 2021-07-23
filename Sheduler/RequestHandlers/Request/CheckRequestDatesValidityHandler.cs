using MediatR;
using Sheduler.Extensions;
using Sheduler.Middlewares.ExceptionHandler;
using Sheduler.Model.Requests;
using Sheduler.Services.DateValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.CheckRequestDatesValidityHandler;

namespace Sheduler.RequestHandlers
{
    public class CheckRequestDatesValidityHandler : IRequestHandler<CheckRequestDatesValidityCommand, Unit>
    {
        public record CheckRequestDatesValidityCommand(Request Request) : IRequest<Unit>;
        private ApplicationContext Context { get; }

        public CheckRequestDatesValidityHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Unit> Handle(CheckRequestDatesValidityCommand request, CancellationToken cancellationToken)
        {
            Request choosenRequest = request.Request;

            ValidateRequestDates(new CommonRequestDateValidator(Context), choosenRequest);

            var validators = new VacationRequestDateValidator(Context)
                .SetNextValidator(new WeekendWorkOffRequestDateValidator(Context));

            ValidateRequestDates(validators, choosenRequest);

            return Unit.Task;
        }

        private void ValidateRequestDates(IRequestDateValidator validator, Request validateRequest)
        {
            try
            {
                validator.Validate(validateRequest);
            }
            catch(Exception exception)
            {
                throw new RestException(exception.Message, HttpStatusCode.BadRequest);
            }
        }

    }
}
