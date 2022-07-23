using MediatR;
using Sheduler.RestApi.Middlewares.ExceptionHandler;
using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.ChangeStatusHandler;

namespace Sheduler.RestApi.RequestHandlers
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
