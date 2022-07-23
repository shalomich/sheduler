using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sheduler.Infrastructure.DataAccess;

namespace Sheduler.Desktop.Infrastructure.Startup
{
    /// <summary>
    /// Contains database migration helper methods.
    /// </summary>
    internal sealed class DatabaseInitializer
    {
        private readonly AppDbContext appDbContext;

        /// <summary>
        /// Database initializer. Performs migration and data seed.
        /// </summary>
        /// <param name="appDbContext">Data context.</param>
        public DatabaseInitializer(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <inheritdoc />
        public async Task InitializeAsync()
        {
            await appDbContext.Database.MigrateAsync();
        }
    }
}
