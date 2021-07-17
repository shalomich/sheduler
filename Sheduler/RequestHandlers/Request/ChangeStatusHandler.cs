using MediatR;
using Sheduler.Middlewares.ExceptionHandler;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.ChangeStatusHandler;

namespace Sheduler.RequestHandlers
{
    public class ChangeStatusHandler : IRequestHandler<ChangeStatusCommand, Unit>
    {
        public record ChangeStatusCommand(Request StatusChangedRequest, RequestStatus NewStatus) : IRequest<Unit>; 
        private ApplicationContext Context { get; }

        public ChangeStatusHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var (statusChangedRequest, newStatus) = request;

            try
            {
                statusChangedRequest.ChangeStatus(newStatus);
                Context.Update(statusChangedRequest);
                await Context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new RestException(exception.Message, HttpStatusCode.BadRequest);
            }

            return Unit.Value;
        }
    }
}
