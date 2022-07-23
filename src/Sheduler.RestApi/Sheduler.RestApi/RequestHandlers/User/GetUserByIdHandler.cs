using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.RestApi.Extensions;
using Sheduler.RestApi.Middlewares.ExceptionHandler;
using Sheduler.RestApi.Model;
using Sheduler.RestApi.Services;
using Sheduler.RestApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.GetUserByIdHandler;

namespace Sheduler.RestApi.RequestHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        public record GetUserByIdQuery(int Id) : IRequest<User>;
        private ApplicationContext Context { get; }
        public GetUserByIdHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await Context.GetAllUsers()
                .SingleOrDefaultAsync(user => user.Id == request.Id);

            if (user == null)
                throw new RestException("", HttpStatusCode.NotFound);

            return user;
        }
    }
}
