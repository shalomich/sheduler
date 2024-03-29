﻿using MediatR;
using Sheduler.RestApi.Model.Requests;
using Sheduler.RestApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.GetVacationTypesHandler;

namespace Sheduler.RestApi.RequestHandlers
{
    public class GetVacationTypesHandler : IRequestHandler<GetVacationTypesQuery, IEnumerable<OptionModel>>
    {
        public record GetVacationTypesQuery() : IRequest<IEnumerable<OptionModel>>;

        public Task<IEnumerable<OptionModel>> Handle(GetVacationTypesQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                return Enum.GetValues<VacationType>()
                    .Select(type => OptionModel.FromEnum(type));
            });
        }

    }
}
