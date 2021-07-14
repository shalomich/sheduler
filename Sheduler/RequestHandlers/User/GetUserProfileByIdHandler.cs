using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Extensions;
using Sheduler.Middlewares.ExceptionHandler;
using Sheduler.Model;
using Sheduler.Services;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.GetUserProfileByIdHandler;

namespace Sheduler.RequestHandlers
{
    public class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfileViewModel>
    {
        public record GetUserProfileByIdQuery(int Id) : IRequest<UserProfileViewModel>;
        private ApplicationContext Context { get; }
        private UserProfileFactory Factory { get; }

        public GetUserProfileByIdHandler(ApplicationContext context, UserProfileFactory factory)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task<UserProfileViewModel> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await Context.GetAllUsers()
            .SingleOrDefaultAsync(user => user.Id == request.Id);

            if (user == null)
                throw new RestException("", HttpStatusCode.NotFound);

            return Factory.Create(user);
        }
    }
}
