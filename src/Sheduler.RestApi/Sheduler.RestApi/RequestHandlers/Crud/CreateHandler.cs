using MediatR;
using Sheduler.RestApi.Middlewares.ExceptionHandler;
using Sheduler.RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.Crud.CreateHandler;

namespace Sheduler.RestApi.RequestHandlers.Crud
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
                throw new RestException("Невалидные данные" ,HttpStatusCode.BadRequest);
            }

            return request.Entity.Id;
        }
    }
}
