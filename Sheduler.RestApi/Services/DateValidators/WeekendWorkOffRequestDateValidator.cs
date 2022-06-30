using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Services.DateValidators
{
    public class WeekendWorkOffRequestDateValidator : ChainRequestDateValidator
    {
        private const string UnequalDateCountMessage = "Количество дней по заявке и отработке должны быть равны";
        private const string WorkOffInstersectChoosendDatesMessage = "Дни по заявке и дни отработки должны быть в разные дни";
        private ApplicationContext Context { get; }
        public WeekendWorkOffRequestDateValidator(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public override void Validate(Request validatedRequest)
        {
            if (validatedRequest is WeekendWorkOffRequest weekendWorkOffValidatedRequest)
            {
                if (weekendWorkOffValidatedRequest.ChoosendDates.Count != weekendWorkOffValidatedRequest.WorkOffDates.Count)
                    throw new ArgumentException(UnequalDateCountMessage);
                
                var intersectDates = weekendWorkOffValidatedRequest.ChoosendDates
                    .Intersect(weekendWorkOffValidatedRequest.WorkOffDates);

                if (intersectDates.Count() != 0)
                    throw new ArgumentException(WorkOffInstersectChoosendDatesMessage);
            }
            else NextValidator?.Validate(validatedRequest);
        }
    }
}
