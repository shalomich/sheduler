using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Extensions;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.GetAllUsers.GetAllUsersHandler;

namespace Sheduler.RequestHandlers.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        public record GetAllUsersQuery() : IRequest<IEnumerable<User>>;
        private ApplicationContext Context { get; }

        public GetAllUsersHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await Context.GetAllUsers().ToListAsync();
        }
    }
}
