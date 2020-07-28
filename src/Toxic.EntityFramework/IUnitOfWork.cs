using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Toxic.EntityFramework
{
    public interface IUnitOfWork<out TDbContext> : IDisposable where TDbContext : DbContext
    {
        TDbContext DbContext { get; }
        
        #region SaveChanges

        int SaveChanges(bool acceptAllChangesOnSuccess = true);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true,
            CancellationToken cancellationToken = default);

        #endregion SaveChanges

        #region Transaction

        IUnitOfWorkTransaction BeginTransaction();

        IUnitOfWorkTransaction BeginTransaction(IsolationLevel isolationLevel);

        Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task<IUnitOfWorkTransaction> BeginTransactionAsync(IsolationLevel isolationLevel,
            CancellationToken cancellationToken = default);

        #endregion Transaction

        #region ExecuteSql

        int ExecuteSqlInterpolated(FormattableString sql);

        Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql,
            CancellationToken cancellationToken = default);

        int ExecuteSqlRaw(string sql, params object[] parameters);

        int ExecuteSqlRaw(string sql, IEnumerable<object> parameters);

        Task<int> ExecuteSqlRawAsync(string sqlCommand, params object[] parameters);

        Task<int> ExecuteSqlRawAsync(string sqlCommand, CancellationToken cancellationToken = default);

        Task<int> ExecuteSqlRawAsync(string sqlCommand, IEnumerable<object> parameters,
            CancellationToken cancellationToken = default);

        #endregion ExecuteSql
    }
}