using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheduler.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.DbConfigs
{
    public class RestRequestDbConfig : IEntityTypeConfiguration<RestRequest>
    {
        public void Configure(EntityTypeBuilder<RestRequest> builder)
        {
            builder.HasOne(request => request.Replacing);
        }
    }
}
