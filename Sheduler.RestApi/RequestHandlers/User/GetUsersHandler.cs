using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.RestApi.Extensions;
using Sheduler.RestApi.Model;
using Sheduler.RestApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.GetAllUsers.GetUsersHandler;

namespace Sheduler.RestApi.RequestHandlers.GetAllUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        public record GetUsersQuery(bool IsManager) : IRequest<IEnumerable<User>>;
        private ApplicationContext Context { get; }
        private IMapper Mapper { get; }

        public GetUsersHandler(ApplicationContext context, IMapper mapper)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var allUsers = Context.GetAllUsers();

            if (request.IsManager)
                allUsers = allUsers.Where(user => user.Role == UserRole.Employee);

            return await allUsers.ToListAsync();

        }
    }
}
