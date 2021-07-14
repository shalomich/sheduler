﻿using MediatR;
using Sheduler.Middlewares.ExceptionHandler;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.Crud.DeleteHandler;

namespace Sheduler.RequestHandlers.Crud
{
    public class DeleteHandler : IRequestHandler<DeleteCommand, Unit>
    {
        public record DeleteCommand(IEntity Entity) : EntityCommand(Entity), IRequest<Unit>;
        private ApplicationContext Context { get; }
        public DeleteHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Context.Remove(request.Entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new RestException(exception.Message, HttpStatusCode.BadRequest);
            }

            return Unit.Value;
        }
    }
}
