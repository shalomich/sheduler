using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.RestApi.DbConfigs
{
    public class RestRequestDbConfig : IEntityTypeConfiguration<RestRequest>
    {
        public void Configure(EntityTypeBuilder<RestRequest> builder)
        {
            builder.HasOne(request => request.Replacing);
        }
    }
}
