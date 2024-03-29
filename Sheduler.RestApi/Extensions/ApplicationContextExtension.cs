﻿using Microsoft.EntityFrameworkCore;
using Sheduler.RestApi.Model;
using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Extensions
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

        public static async Task<IEnumerable<DateTime>> GetBusyDatesAsync(this ApplicationContext context, int userId)
        {
            IEnumerable<Request> allRequests = await context.GetAllRequestsAsync();

            return allRequests
                .Where(request => request.CreatorId == userId)
                .Select(request => request.ChoosendDates)
                .Aggregate(new HashSet<DateTime>(), (dates1, dates2) => dates2.Count != 0 ? dates1.Concat(dates2).ToHashSet() : dates1);

        }
    }
}
