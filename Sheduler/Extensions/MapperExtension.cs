using AutoMapper;
using Sheduler.Model.Requests;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Extensions
{
    public static class MapperExtension
    {
        public static Request MapRequestFromForm(this IMapper mapper, RequestFormViewModel formRequestModel)
        {
            Type requestType = formRequestModel.GetType().Assembly
                .GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Request)) && type.IsAbstract == false)
                .SingleOrDefault(type => type.Name == formRequestModel.Type);

            return (Request) mapper.Map(formRequestModel, formRequestModel.GetType(), requestType);
        }
    }
}
