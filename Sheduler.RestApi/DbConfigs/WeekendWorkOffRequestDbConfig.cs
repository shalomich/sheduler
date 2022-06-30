using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.DbConfigs
{
    public class WeekendWorkOffRequestDbConfig : IEntityTypeConfiguration<WeekendWorkOffRequest>
    {
        public void Configure(EntityTypeBuilder<WeekendWorkOffRequest> builder)
        {
            builder.Property(request => request.WorkOffDates)
            .HasConversion(
                dates => FromDatesToStringConvert(dates),
                datesString => FromStringToDates(datesString)
                    .ToHashSet());
        }

        public string FromDatesToStringConvert(IEnumerable<DateTime> dates) => dates
                        .Select(date => date.ToString())
                        .Aggregate((firstDate, secondDate) => $"{firstDate},{secondDate}");

        public IEnumerable<DateTime> FromStringToDates(string datesString) => datesString
                        .Split(',', StringSplitOptions.None)
                        .Select(dateString => DateTime.Parse(dateString));
    }
}
