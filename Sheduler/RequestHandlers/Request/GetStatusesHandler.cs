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
    public class GetStatusesHandler : IRequestHandler<GetStatusesQuery, IEnumerable<OptionModel>>
    {
        public record GetStatusesQuery() : IRequest<IEnumerable<OptionModel>>; 
        public Task<IEnumerable<OptionModel>> Handle(GetStatusesQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return Enum.GetValues<RequestStatus>()
                    .Select(status => OptionModel.FromEnum(status));
            });
        }
    }
}
