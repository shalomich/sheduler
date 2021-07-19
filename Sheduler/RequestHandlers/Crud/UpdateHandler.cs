﻿using MediatR;
using Sheduler.Middlewares.ExceptionHandler;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.Crud.UpdateHandler;

namespace Sheduler.RequestHandlers.Crud
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, Unit>
    {
        public record UpdateCommand(int Id, IEntity Entity) : EntityCommand(Entity), IRequest<Unit>;

        private const string WrongIdMessage = "Id from route and body are different";

        private ApplicationContext Context { get; }

        

        public UpdateHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var (id, entity) = request;

            if (entity.Id != id)
            {
                throw new RestException(WrongIdMessage,HttpStatusCode.BadRequest);
            }

            try
            {
                Context.Update(entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                throw new RestException("Updating error", HttpStatusCode.BadRequest, exception);
            }

            return Unit.Value;
        }
    }
}
