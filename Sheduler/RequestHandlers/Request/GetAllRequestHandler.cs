using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Extensions;
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
        public record GetAllRequestQuery() : IRequest<IEnumerable<Request>>;
        private ApplicationContext Context { get; }

        public GetAllRequestHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Request>> Handle(GetAllRequestQuery request, CancellationToken cancellationToken)
        {
            return await Context.GetAllRequestsAsync();
        }
    }
}
