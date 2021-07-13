using MediatR;
using Sheduler.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sheduler.RequestHandlers.Form.GetBuildingData
{
    public class GetFormHandler : IRequestHandler<GetFormQuery, IEnumerable<object>>
    {
        private ToFormConverter Converter { get; }

        public GetFormHandler(ToFormConverter converter)
        {
            Converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public Task<IEnumerable<object>> Handle(GetFormQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => Converter.Convert(request.ModelType));
        }
    }
}
