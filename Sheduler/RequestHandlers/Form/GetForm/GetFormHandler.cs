using MediatR;
using Sheduler.Middlewares.ExceptionHandler;
using Sheduler.Services;
using Sheduler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.Form.GetForm.GetFormHandler;
using static Sheduler.Services.ToFormConverter;

namespace Sheduler.RequestHandlers.Form.GetForm
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
