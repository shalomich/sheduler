using MediatR;
using Sheduler.Extensions;
using Sheduler.Middlewares.ExceptionHandler;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using static Sheduler.RequestHandlers.CheckRequestDatesValidityHandler;

namespace Sheduler.RequestHandlers
{
    public class CheckRequestDatesValidityHandler : IRequestHandler<CheckRequestDatesValidityCommand, Unit>
    {
        public record CheckRequestDatesValidityCommand(Request Request) : IRequest<Unit>;

        private const string BusyDatesMessage = "Нельзя выбрать эти даты {0}, они заняты другими заявками";

        private const string ChoosenDatesMessage = "Нельзя выбрать эти даты {0}, они заняты текущей заявкой";

        private ApplicationContext Context { get; }

        public CheckRequestDatesValidityHandler(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(CheckRequestDatesValidityCommand request, CancellationToken cancellationToken)
        {
            Request choosenRequest = request.Request;

            IEnumerable<Request> allRequests = await Context.GetAllRequestsAsync();

            var busyDates = allRequests
                .Where(userRequest => userRequest.CreatorId == choosenRequest.CreatorId)
                .Select(userRequest => userRequest.ChoosendDates)
                .ToList();

            var a = busyDates.Aggregate(new HashSet<DateTime>(),(dates1, dates2) => dates2.Count != 0 ? dates1.Concat(dates2).ToHashSet() : dates1);

            CheckDates(a, choosenRequest.ChoosendDates, BusyDatesMessage);

            if (choosenRequest is WeekendWorkOffRequest workOffRequest)
            {
                if (workOffRequest.ChoosendDates.Count != workOffRequest.WorkOffDates.Count)
                    throw new RestException("Количество дней по заявке и отработке должны быть равны", HttpStatusCode.BadRequest);

                CheckDates(workOffRequest.ChoosendDates, workOffRequest.WorkOffDates, ChoosenDatesMessage);
                CheckDates(a, workOffRequest.WorkOffDates, BusyDatesMessage);
            }

            return Unit.Value;
        }

        private void CheckDates(IEnumerable<DateTime> dates1, IEnumerable<DateTime> dates2, string errorMessage)
        {
            Func<IEnumerable<DateTime>, string> convertDatesToString = dates => dates
                 .Select(dates => dates.ToDateString())
                 .Aggregate((date1, date2) => $"{date1}, {date2}");

            var intersectDates = dates1.Intersect(dates2);

            if (intersectDates.Count() != 0)
                throw new RestException(String.Format(errorMessage,
                    convertDatesToString(intersectDates)), HttpStatusCode.BadRequest);
        }

    }
}
