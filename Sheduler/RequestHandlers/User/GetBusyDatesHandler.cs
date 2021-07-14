using MediatR;
using Sheduler.Extensions;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.GetBusyDatesHandler;

namespace Sheduler.RequestHandlers
{
    public class GetBusyDatesHandler : IRequestHandler<GetBusyDatesQuery, ISet<DateTime>>
    {
        public record GetBusyDatesQuery(int UserId) : IRequest<ISet<DateTime>>;
        private ApplicationContext Context { get; }
        public GetBusyDatesHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ISet<DateTime>> Handle(GetBusyDatesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Request> allRequests = await Context.GetAllRequestsAsync();

            return allRequests
                .Where(userRequest => userRequest.Id == request.UserId)
                .Select(userRequest => userRequest.ChoosendDates)
                .Aggregate((dates1, dates2) => dates1.Concat(dates2).ToHashSet());
        }
    }
}
