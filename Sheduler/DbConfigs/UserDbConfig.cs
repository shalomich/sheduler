using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler.DbConfigs
{
    public class UserDbConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(account => account.Email);
            builder.Property(account => account.Email).IsRequired();
            builder.HasIndex(account => account.Email).IsUnique();

            builder.Property(account => account.Password).IsRequired();

            builder.HasIndex(account => account.PhoneNumber).IsUnique();

            builder.Property(user => user.Role).HasConversion<string>();
        }
    }
}
