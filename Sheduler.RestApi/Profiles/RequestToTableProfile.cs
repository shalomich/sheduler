﻿using AutoMapper;
using Sheduler.RestApi.Extensions;
using Sheduler.RestApi.Model.Requests;
using Sheduler.RestApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Profiles
{
    public class RequestToTableProfile : Profile
    {
        public RequestToTableProfile()
        {
            CreateMap<Request, RequestTableViewModel>()
                .ForMember(view => view.CreatorName,
                    mapper => mapper.MapFrom(model => model.Creator.Name))
                .ForMember(view => view.ApprovingName,
                    mapper => mapper.MapFrom(model => model.Approving.Name))
                .ForMember(view => view.Status,
                    mapper => mapper.MapFrom(model => model.Status.ToString()))
                .ForMember(view => view.ChoosendDates,
                    mapper => mapper.MapFrom(model => model.ChoosendDates
                        .Select(date => date.ToDateString())
                        .Aggregate((date1, date2) => $"{date1}, {date2}")))
                .ForMember(view => view.CreationDate,
                    mapper => mapper.MapFrom(model => model.CreationDate.ToDateString()));
        }
    }
}
