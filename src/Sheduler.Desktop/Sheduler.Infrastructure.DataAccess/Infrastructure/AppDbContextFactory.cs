using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sheduler.Infrastructure.DataAccess.Infrastructure
{
    /// <summary>
    /// Design-time <see cref="AppDbContext"/> factory. It uses when EF.Core creates a migration.
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /// <inheritdoc/>
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // In design-time we don't use a real connection string, so we can use any string for configuring.
            var anyConnectionString = "0";
            optionsBuilder.UseSqlServer(anyConnectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
