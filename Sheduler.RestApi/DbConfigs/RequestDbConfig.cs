using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.DbConfigs
{
    public class RequestDbConfig : IEntityTypeConfiguration<Request>
    {
        public virtual void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasOne(request => request.Creator)
                .WithMany(user => user.Requests)
                .HasForeignKey(request => request.CreatorId);
           
            builder.Property<RequestStatus>("_currentStatus")
                   .HasColumnName("RequestStatus")
                   .IsRequired()
                   .HasConversion
                   (
                        status => status.ToString(),
                        requestStatus => (RequestStatus) Enum.Parse(typeof(RequestStatus), requestStatus)
                   );

            builder.HasDiscriminator<string>("RequestType")
                   .HasValue<VacationRequest>(new VacationRequest().Type)
                   .HasValue<WeekendVacationRequest>(new WeekendVacationRequest().Type)
                   .HasValue<WeekendWorkOffRequest>(new WeekendWorkOffRequest().Type)
                   .HasValue<DayOffRequest>(new DayOffRequest().Type)
                   .HasValue<RemoteWorkRequest>(new RemoteWorkRequest().Type);
            
            builder.Property(request => request.ChoosendDates)
                .IsRequired()
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
