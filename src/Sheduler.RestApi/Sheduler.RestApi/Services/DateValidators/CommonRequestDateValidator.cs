using Sheduler.RestApi.Extensions;
using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Services.DateValidators
{
    public class CommonRequestDateValidator : IRequestDateValidator
    {

        private const string BusyDatesMessage = "Нельзя выбрать эти даты {0}, они заняты другими заявками";
        private ApplicationContext Context { get; }

        public CommonRequestDateValidator(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async void Validate(Request validatedRequest)
        {
            IEnumerable<Request> allRequests = await Context.GetAllRequestsAsync();

            ISet<DateTime> busyDates = allRequests
                .Where(request => request.CreatorId == validatedRequest.CreatorId 
                    && request.Id != validatedRequest.Id)
                .Select(request => request.ChoosendDates)
                .Aggregate(new HashSet<DateTime>(), (dates1, dates2) => dates2.Count != 0 ? dates1.Concat(dates2).ToHashSet() : dates1);

            var intersectDates = busyDates.Intersect(validatedRequest.ChoosendDates);

            if (intersectDates.Count() != 0)
                throw new ArgumentOutOfRangeException(string.Format(BusyDatesMessage, intersectDates.AggregateDates()));

        }
    }
}
