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
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, OptionViewModel>
    {
        public record GetPostsQuery() : IRequest<OptionViewModel>;
        private ApplicationContext Context { get; }

        public GetPostsHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<OptionViewModel> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var options = await Context.Posts
                .Select(post => new OptionModel(post.Name, post.Name)).ToListAsync();

            return new OptionViewModel(options);
        }
    }
}
