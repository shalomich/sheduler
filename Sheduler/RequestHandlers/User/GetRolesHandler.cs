using MediatR;
using Sheduler.Model;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.GetRolesHandler;

namespace Sheduler.RequestHandlers
{
    public class GetRolesHandler : IRequestHandler<GetRolesQuery, OptionViewModel>
    {
        public record GetRolesQuery() : IRequest<OptionViewModel>;

        public Task<OptionViewModel> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => 
            {
                var options = Enum.GetValues<UserRole>()
                    .Select(role => OptionModel.FromEnum(role))
                    .ToList();

                return new OptionViewModel(options);
            });
        }

        
    }
}
