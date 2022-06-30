using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.RestApi.Extensions;
using Sheduler.RestApi.Middlewares.ExceptionHandler;
using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.GetRequestByIdHandler;

namespace Sheduler.RestApi.RequestHandlers
{
    public class GetRequestByIdHandler : IRequestHandler<GetRequestByIdQuery, Request>
    {
        public record GetRequestByIdQuery(int Id) : IRequest<Request>;
        private ApplicationContext Context { get; }
        public GetRequestByIdHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Request> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Request> allRequests = await Context.GetAllRequestsAsync();

            Request requestById = allRequests
                .SingleOrDefault(choosenRequest => choosenRequest.Id == request.Id);

            if (requestById == null)
                throw new RestException("", HttpStatusCode.NotFound);

            if (requestById is RestRequest restRequestById)
            {
                Context.Entry(restRequestById).Reference(request => request.Replacing).Load();
                return restRequestById;
            }

            return requestById;
        }
    }
}
