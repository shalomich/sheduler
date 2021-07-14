using MediatR;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RequestHandlers.Crud.GetById
{
    public record GetByIdQuery(int Id, Type Type) : IRequest<IEntity>
    {
        private Type _entityType;        
        public Type EntityType
        {
            init
            {
                if (Type.GetInterfaces().Any(i => i == typeof(IEntity)) == false)
                    throw new ArgumentException();
                _entityType = Type;
            }
            get
            {
                return _entityType;
            }
        }
    }
}
