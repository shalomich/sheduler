using MediatR;
using Sheduler.Model;
using Sheduler.Model.Requests;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.GetStatusesHandler;

namespace Sheduler.RequestHandlers
{
    public class GetStatusesHandler : IRequestHandler<GetStatusesQuery, OptionViewModel>
    {
        public record GetStatusesQuery() : IRequest<OptionViewModel>; 
        public Task<OptionViewModel> Handle(GetStatusesQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var options = Enum.GetValues<RequestStatus>()
                    .Select(status => OptionModel.FromEnum(status))
                    .ToList();

                return new OptionViewModel(options);
            });
        }
    }
}
