using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Model;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.GetPostsHandler;

namespace Sheduler.RequestHandlers
{
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, IEnumerable<OptionModel>>
    {
        public record GetPostsQuery() : IRequest<IEnumerable<OptionModel>>;
        private ApplicationContext Context { get; }

        public GetPostsHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<OptionModel>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return await Context.Posts
                .Select(post => new OptionModel(post.Name, post.Id.ToString())).ToListAsync();
        }
    }
}
