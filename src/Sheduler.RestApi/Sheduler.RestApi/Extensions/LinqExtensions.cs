using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Extensions
{
    public static class LinqExtensions
    {
        public static string AggregateDates(this IEnumerable<DateTime> dates)
        {
            return dates.Select(dates => dates.ToDateString())
                 .Aggregate((date1, date2) => $"{date1}, {date2}");
        }
    }
}
