using AutoMapper;
using MediatR;
using Sheduler.RestApi.Extensions;
using Sheduler.RestApi.Model;
using Sheduler.RestApi.Model.Requests;
using Sheduler.RestApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RestApi.RequestHandlers.GetUserProfileHandler;

namespace Sheduler.RestApi.RequestHandlers
{
    public class GetUserProfileHandler : IRequestHandler<GetUserProfileQuery, UserProfileViewModel>
    {       
        public record GetUserProfileQuery(User User) : IRequest<UserProfileViewModel>;

        private const int DayCountInWeek = 7;
        private const int WorkDayCountInWeek = 5;
        private const int VacationDayCount = 20;

        private ApplicationContext Context { get; }
        private IMapper Mapper { get; }

        public GetUserProfileHandler(ApplicationContext context, IMapper mapper)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserProfileViewModel> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var user = request.User;

            var yearBeginning = new DateTime(DateTime.Now.Year, 1, 1);
            var yearEnd = new DateTime(DateTime.Now.Year, 12, 31);
            var now = DateTime.Now;

            DateTime countdownDate = user.AccountCreatingDate.Year > yearBeginning.Year
                ? yearBeginning : user.AccountCreatingDate;

            Func<DateTime, DateTime, int> CalculateWorkDays = (begin, end) => (int)(end.Subtract(begin).TotalDays / DayCountInWeek * WorkDayCountInWeek);

            var allRequests = await Context.GetAllRequestsAsync();

            int busyDateCount = allRequests
                .Where(request => request.Status == RequestStatus.Allowed
                    && request.CreatorId == user.Id
                    && request.ChoosendDates.All(date => date < now))
                .Sum(request => request.ChoosendDates.Count());

            int workedDaysPerYear = CalculateWorkDays(countdownDate, now) - busyDateCount;

            int unusedVacationDaysPerYear = VacationDayCount - allRequests
                .Where(request => request is VacationRequest vacationRequest
                    && vacationRequest.VacationType == VacationType.BasicPaidVacation
                    && vacationRequest.Status == RequestStatus.Allowed)
                .Sum(request => request.ChoosendDates.Count());

            /*
            int dayOffQuantity = Context.DayOffRequests
                .Where(request => request.Status == RequestStatus.Allowed)
                .Sum(request => request.ChoosendDates.Count());
            */

            var profile = Mapper.Map<UserProfileViewModel>(user);

            profile.WorkedDaysPerYear = workedDaysPerYear;
            profile.UnusedVacationDaysPerYear = unusedVacationDaysPerYear;

            return profile;
        }
    }
}
