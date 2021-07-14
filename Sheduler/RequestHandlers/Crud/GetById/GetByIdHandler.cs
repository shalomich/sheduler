using MediatR;
using Sheduler.Middlewares.ExceptionHandler;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Sheduler.RequestHandlers.Crud.GetById
{
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, IEntity>
    {
        private ApplicationContext Context { get; }

        private const string WrongIdMessage = "Entity does not exist by this id";

        public GetByIdHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEntity> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var (id, type) = request;

            var entity = (IEntity) await Context.FindAsync(type, id);

            if (entity == null)
                throw new RestException(WrongIdMessage, HttpStatusCode.NotFound);
            
            return entity;       
        }
    }
}
