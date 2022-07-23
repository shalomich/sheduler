using MediatR;
using Sheduler.RestApi.Model;
using Sheduler.RestApi.Model.Requests;
using Sheduler.RestApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.GetStatusesHandler;

namespace Sheduler.RestApi.RequestHandlers
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
