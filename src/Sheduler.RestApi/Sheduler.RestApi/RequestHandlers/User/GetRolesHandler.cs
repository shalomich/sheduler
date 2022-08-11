using MediatR;
using Sheduler.RestApi.ViewModels;
using Sheduler.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.GetRolesHandler;

namespace Sheduler.RestApi.RequestHandlers
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, IEnumerable<OptionModel>>
    {
        public record GetRolesQuery() : IRequest<IEnumerable<OptionModel>>;

        public Task<IEnumerable<OptionModel>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => 
            {
                return Enum.GetValues<UserRole>()
                    .Select(role => OptionModel.FromEnum(role));
            });
        }

        
    }
}
