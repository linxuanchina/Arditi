using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Toxic.EntityFramework
{
    public sealed class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext> where TDbContext : DbContext
    {
        public TDbContext DbContext { get; }

        public UnitOfWork(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }

        #region SaveChanges

        public int SaveChanges(bool acceptAllChangesOnSuccess = true)
        {
            return DbContext.SaveChanges(acceptAllChangesOnSuccess);
        }

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default)
        {
            return DbContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion SaveChanges

        #region Transaction

        public IUnitOfWorkTransaction BeginTransaction()
        {
            return new UnitOfWorkTransaction(DbContext.Database.BeginTransaction());
        }

        public IUnitOfWorkTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return new UnitOfWorkTransaction(DbContext.Database.BeginTransaction(isolationLevel));
        }

        public async Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return new UnitOfWorkTransaction(await DbContext.Database.BeginTransactionAsync(cancellationToken));
        }

        public async Task<IUnitOfWorkTransaction> BeginTransactionAsync(IsolationLevel isolationLevel,
            CancellationToken cancellationToken = default)
        {
            return new UnitOfWorkTransaction(
                await DbContext.Database.BeginTransactionAsync(isolationLevel, cancellationToken));
        }

        #endregion Transaction

        #region ExecuteSql

        public int ExecuteSqlInterpolated(FormattableString sql)
        {
            return DbContext.Database.ExecuteSqlInterpolated(sql);
        }

        public Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql, CancellationToken cancellationToken = default)
        {
            return DbContext.Database.ExecuteSqlInterpolatedAsync(sql, cancellationToken);
        }

        public int ExecuteSqlRaw(string sql, params object[] parameters)
        {
            return DbContext.Database.ExecuteSqlRaw(sql, parameters);
        }

        public int ExecuteSqlRaw(string sql, IEnumerable<object> parameters)
        {
            return DbContext.Database.ExecuteSqlRaw(sql, parameters);
        }

        public Task<int> ExecuteSqlRawAsync(string sqlCommand, params object[] parameters)
        {
            return DbContext.Database.ExecuteSqlRawAsync(sqlCommand, parameters);
        }

        public Task<int> ExecuteSqlRawAsync(string sqlCommand, CancellationToken cancellationToken = default)
        {
            return DbContext.Database.ExecuteSqlRawAsync(sqlCommand, cancellationToken);
        }

        public Task<int> ExecuteSqlRawAsync(string sqlCommand, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
        {
            return DbContext.Database.ExecuteSqlRawAsync(sqlCommand, parameters, cancellationToken);
        }

        #endregion ExecuteSql
    }
}