using Microsoft.EntityFrameworkCore;
using Sheduler.RestApi.DbConfigs;
using Sheduler.RestApi.Model;
using Sheduler.RestApi.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheduler
{
    public class ApplicationContext : DbContext
    {
        public DbSet<WeekendWorkOffRequest> WeekendWorkOffRequests { set; get; }
        public DbSet<WeekendVacationRequest> WeekendVacationRequests { set; get; }
        public DbSet<VacationRequest> VacationRequests { set; get; }
        public DbSet<DayOffRequest> DayOffRequests { set; get; }
        public DbSet<RemoteWorkRequest> RemoteWorkRequests { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<Post> Posts { set; get; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserDbConfig());
            modelBuilder.ApplyConfiguration(new RequestDbConfig());
            modelBuilder.ApplyConfiguration(new PostDbConfig());
            modelBuilder.ApplyConfiguration(new RestRequestDbConfig());
            modelBuilder.ApplyConfiguration(new VacationRequestDbConfig());
            modelBuilder.ApplyConfiguration(new WeekendWorkOffRequestDbConfig());
        }
    }
}
