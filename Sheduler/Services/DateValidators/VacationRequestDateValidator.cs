using Sheduler.Extensions;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Services.DateValidators
{
    public class VacationRequestDateValidator : ChainRequestDateValidator
    {
        private const int MaxVacationDayCount = 20;
        private const string UnusedVacationDaysCountMessage = "Количество дней по заявке больше чем неиспользованных дней отпуска({0})";
        private ApplicationContext Context { get; }
        
        public VacationRequestDateValidator(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public override void Validate(Request validatedRequest)
        {
            if (validatedRequest is VacationRequest validatedVacationRequest)
            {
                int usedVacationDaysCount = Context.VacationRequests
                    .Where(request => request.VacationType == VacationType.BasicPaidVacation
                        && request.Status == RequestStatus.Allowed)
                    .Sum(request => request.ChoosendDates.Count());

                int unusedVacationDaysCount = MaxVacationDayCount - usedVacationDaysCount;

                if (unusedVacationDaysCount < validatedVacationRequest.ChoosendDates.Count)
                    throw new ArgumentOutOfRangeException(string.Format(UnusedVacationDaysCountMessage, unusedVacationDaysCount));
            }
            else NextValidator?.Validate(validatedRequest);
        }
    }
}
