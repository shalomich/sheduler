using MediatR;
using Sheduler.Middlewares.ExceptionHandler;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.Crud.CreateHandler;

namespace Sheduler.RequestHandlers.Crud
{
    public class CreateHandler : IRequestHandler<CreateCommand,int>
    {
        public record CreateCommand(IEntity Entity) : EntityCommand(Entity), IRequest<int>;
        private ApplicationContext Context { get; }

        public CreateHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await Context.AddAsync(request.Entity);
                await Context.SaveChangesAsync();
            }
            catch(Exception exception)
            {
                throw new RestException("Creation error" ,HttpStatusCode.BadRequest,exception);
            }

            return request.Entity.Id;
        }
    }
}
