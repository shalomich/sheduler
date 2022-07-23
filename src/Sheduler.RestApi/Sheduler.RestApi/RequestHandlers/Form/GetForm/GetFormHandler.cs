using MediatR;
using Sheduler.RestApi.Middlewares.ExceptionHandler;
using Sheduler.RestApi.Services;
using Sheduler.RestApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.Form.GetForm.GetFormHandler;
using static Sheduler.RestApi.Services.ToFormConverter;

namespace Sheduler.RestApi.RequestHandlers.Form.GetForm
{
    public class GetFormHandler : IRequestHandler<GetFormQuery, FormTemplateViewModel>
    {
        public record GetFormQuery(string FormModelName) : IRequest<FormTemplateViewModel>;

        private const string WrongFormModelName = "This form model name does not exist";
        private ToFormConverter Converter { get; }

        public GetFormHandler(ToFormConverter converter)
        {
            Converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public Task<FormTemplateViewModel> Handle(GetFormQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<FormField> formTemplate;

            try
            {
                formTemplate = Converter.Convert(request.FormModelName);
                return Task.Run(()=> new FormTemplateViewModel(formTemplate));
            }
            catch (Exception)
            {
                throw new RestException(WrongFormModelName, HttpStatusCode.NotFound);
            }
        }
    }
}
