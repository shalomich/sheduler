using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Extensions;
using Sheduler.Model;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.GetAllUsers.GetUserSummariesHandler;

namespace Sheduler.RequestHandlers.GetAllUsers
{
    public class GetUserSummariesHandler : IRequestHandler<GetUserSummariesQuery, IEnumerable<UserSummaryViewModel>>
    {
        public record GetUserSummariesQuery() : IRequest<IEnumerable<UserSummaryViewModel>>;
        private ApplicationContext Context { get; }
        private IMapper Mapper { get; }

        public GetUserSummariesHandler(ApplicationContext context, IMapper mapper)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UserSummaryViewModel>> Handle(GetUserSummariesQuery request, CancellationToken cancellationToken)
        {
            var users = await Context.GetAllUsers().ToListAsync();

            return users.Select(user => Mapper.Map<UserSummaryViewModel>(user));
        }
    }
}
