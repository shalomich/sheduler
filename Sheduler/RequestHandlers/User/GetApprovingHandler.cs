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
using static Sheduler.RequestHandlers.GetApprovingHandler;

namespace Sheduler.RequestHandlers
{
    public class GetApprovingHandler : IRequestHandler<GetApprovingQuery, IEnumerable<OptionModel>>
    {
        public record GetApprovingQuery(int UserId) : IRequest<IEnumerable<OptionModel>>;

        private ApplicationContext Context { get; }
        public GetApprovingHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<OptionModel>> Handle(GetApprovingQuery request, CancellationToken cancellationToken)
        {
            return await Context.GetAllUsers()
                .Where(user => user.Role == UserRole.Director || user.Role == UserRole.Manager)
                .Where(user => user.Name != null && user.Id != request.UserId)
                .Select(user => new OptionModel(user.Name, user.Id.ToString()))
                .ToListAsync();
        }

    }
}
