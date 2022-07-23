using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sheduler.Domain.Store.Entities;
using Sheduler.Domain.Users.Entities;

namespace Sheduler.Infrastructure.Abstractions.Interfaces
{
    /// <summary>
    /// Application abstraction for unit of work.
    /// </summary>
    public interface IAppDbContext : IDbContextWithSets, IDisposable
    {
        #region Users

        /// <summary>
        /// Users.
        /// </summary>
        DbSet<User> Users { get; }

        #endregion

        #region Store

        /// <summary>
        /// Products set.
        /// </summary>
        DbSet<Product> Products { get; }

        #endregion

        /// <inheritdoc cref="Microsoft.EntityFrameworkCore.DbContext.Entry(object)"/>
        EntityEntry Entry(object entity);

        /// <inheritdoc cref="Microsoft.EntityFrameworkCore.DbContext.Entry{TEntity}(TEntity)"/>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
