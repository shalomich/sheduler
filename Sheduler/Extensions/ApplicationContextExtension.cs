using Microsoft.EntityFrameworkCore;
using Sheduler.Model;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.Extensions
{
    public static class ApplicationContextExtension
    {
        public async static Task<IEnumerable<Request>> GetAllRequestsAsync(this ApplicationContext context)
        {
            Func<IQueryable<Request>, Task<IEnumerable<Request>>> getRequestsQuery = async query => 
                await query.Include(request => request.Creator)
                           .Include(request => request.Approving)
                           .ToListAsync();
            IQueryable<Request>[] requestsDataSets = new IQueryable<Request>[]
            {
                context.VacationRequests,
                context.WeekendVacationRequests,
                context.WeekendWorkOffRequests,
                context.DayOffRequests,
                context.RemoteWorkRequests
            };

            IEnumerable<Request> allRequests = new List<Request>();

            foreach (var requestDataSet in requestsDataSets)
            {
                var requests = await getRequestsQuery(requestDataSet);
                allRequests = allRequests.Concat(requests);
            }

            return allRequests;
        }

        public static IQueryable<User> GetAllUsers(this ApplicationContext context)
        {
            return context.Users.Include(user => user.Post);
        }
    }
}
