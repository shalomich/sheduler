using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Extensions;
using Sheduler.Model;
using Sheduler.Model.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.GetAllRequestHandler;

namespace Sheduler.RequestHandlers
{
    public class GetAllRequestHandler : IRequestHandler<GetAllRequestQuery,IEnumerable<Request>>
    {
        public record GetAllRequestQuery(int UserId, bool IsEmployee) : IRequest<IEnumerable<Request>>;
        private ApplicationContext Context { get; }

        public GetAllRequestHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Request>> Handle(GetAllRequestQuery request, CancellationToken cancellationToken)
        {
            var (userId, isEmployee) = request;
            
            var allRequests = await Context.GetAllRequestsAsync();

            if (isEmployee)
                return allRequests.Where(request => request.CreatorId == userId);

            return allRequests;
        }
    }
}
