﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.RestApi.Extensions;
using Sheduler.RestApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.GetReplacingHandler;

namespace Sheduler.RestApi.RequestHandlers
{
    public class GetReplacingHandler : IRequestHandler<GetReplacingQuery, IEnumerable<OptionModel>>
    {
        public record GetReplacingQuery(int UserId) : IRequest<IEnumerable<OptionModel>>;
        private ApplicationContext Context { get; }
        public GetReplacingHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<OptionModel>> Handle(GetReplacingQuery request, CancellationToken cancellationToken)
        {
            return await Context.GetAllUsers()
                .Where(user => user.Name != null && user.Id != request.UserId)
                .Select(user => new OptionModel(user.Name, user.Id.ToString()))
                .ToListAsync();
        }

    }
}
