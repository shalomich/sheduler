using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.Extensions
{
    public static class DateTimeExtensions
    {
        public static String ToDateString(this DateTime date)
        {
            return date.Date.ToString("dd/MM/yyyy");
        }
    }
}
