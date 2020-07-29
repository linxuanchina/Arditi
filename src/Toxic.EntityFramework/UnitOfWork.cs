using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Toxic.EntityFramework
{
    public sealed class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        #region SaveChanges

        public int SaveChanges(bool acceptAllChangesOnSuccess = true)
        {
            foreach (var entityEntry in _dbContext.ChangeTracker.Entries())
            {
                if (entityEntry.State == EntityState.Added && entityEntry.Entity is IAuditEntity)
                {
                    entityEntry.Property(ShadowProperty.CreatedOn).CurrentValue = DateTime.Now;
                    entityEntry.Property(ShadowProperty.ModifiedOn).CurrentValue = null;
                    if (entityEntry.Entity is ISoftDeleteEntity)
                    {
                        entityEntry.Property(ShadowProperty.IsDeleted).CurrentValue = false;
                        entityEntry.Property(ShadowProperty.DeletedOn).CurrentValue = null;
                    }
                }
                else if (entityEntry.State == EntityState.Modified && entityEntry.Entity is IAuditEntity)
                {
                    entityEntry.Property(ShadowProperty.ModifiedOn).CurrentValue = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Deleted && entityEntry.Entity is ISoftDeleteEntity)
                {
                    entityEntry.Property(ShadowProperty.IsDeleted).CurrentValue = true;
                    entityEntry.Property(ShadowProperty.DeletedOn).CurrentValue = DateTime.Now;
                    entityEntry.State = EntityState.Modified;
                }
            }

            return _dbContext.SaveChanges(acceptAllChangesOnSuccess);
        }

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true,
            CancellationToken cancellationToken = default)
        {
            foreach (var entityEntry in _dbContext.ChangeTracker.Entries())
            {
                if (entityEntry.State == EntityState.Added && entityEntry.Entity is IAuditEntity)
                {
                    entityEntry.Property(ShadowProperty.CreatedOn).CurrentValue = DateTime.Now;
                    entityEntry.Property(ShadowProperty.ModifiedOn).CurrentValue = null;
                    if (entityEntry.Entity is ISoftDeleteEntity)
                    {
                        entityEntry.Property(ShadowProperty.IsDeleted).CurrentValue = false;
                        entityEntry.Property(ShadowProperty.DeletedOn).CurrentValue = null;
                    }
                }
                else if (entityEntry.State == EntityState.Modified && entityEntry.Entity is IAuditEntity)
                {
                    entityEntry.Property(ShadowProperty.ModifiedOn).CurrentValue = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Deleted && entityEntry.Entity is ISoftDeleteEntity)
                {
                    entityEntry.Property(ShadowProperty.IsDeleted).CurrentValue = true;
                    entityEntry.Property(ShadowProperty.DeletedOn).CurrentValue = DateTime.Now;
                    entityEntry.State = EntityState.Modified;
                }
            }

            return _dbContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion SaveChanges

        #region Transaction

        public IUnitOfWorkTransaction BeginTransaction()
        {
            return new UnitOfWorkTransaction(_dbContext.Database.BeginTransaction());
        }

        public IUnitOfWorkTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return new UnitOfWorkTransaction(_dbContext.Database.BeginTransaction(isolationLevel));
        }

        public async Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return new UnitOfWorkTransaction(await _dbContext.Database.BeginTransactionAsync(cancellationToken));
        }

        public async Task<IUnitOfWorkTransaction> BeginTransactionAsync(IsolationLevel isolationLevel,
            CancellationToken cancellationToken = default)
        {
            return new UnitOfWorkTransaction(
                await _dbContext.Database.BeginTransactionAsync(isolationLevel, cancellationToken));
        }

        #endregion Transaction

        #region ExecuteSql

        public int ExecuteSqlInterpolated(FormattableString sql)
        {
            return _dbContext.Database.ExecuteSqlInterpolated(sql);
        }

        public Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql,
            CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.ExecuteSqlInterpolatedAsync(sql, cancellationToken);
        }

        public int ExecuteSqlRaw(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, parameters);
        }

        public int ExecuteSqlRaw(string sql, IEnumerable<object> parameters)
        {
            return _dbContext.Database.ExecuteSqlRaw(sql, parameters);
        }

        public Task<int> ExecuteSqlRawAsync(string sqlCommand, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sqlCommand, parameters);
        }

        public Task<int> ExecuteSqlRawAsync(string sqlCommand, CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sqlCommand, cancellationToken);
        }

        public Task<int> ExecuteSqlRawAsync(string sqlCommand, IEnumerable<object> parameters,
            CancellationToken cancellationToken = default)
        {
            return _dbContext.Database.ExecuteSqlRawAsync(sqlCommand, parameters, cancellationToken);
        }

        #endregion ExecuteSql
    }
}