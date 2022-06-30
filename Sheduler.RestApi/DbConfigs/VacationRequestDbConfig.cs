using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.DbConfigs
{
    public class VacationRequestDbConfig : IEntityTypeConfiguration<VacationRequest>
    {
        public void Configure(EntityTypeBuilder<VacationRequest> builder)
        {
            builder.Property(request => request.VacationType).IsRequired();
            builder.Property(request => request.VacationType).HasConversion<string>();
            builder.Property(request => request.IsDateChangeable).IsRequired();
        }
    }
}
