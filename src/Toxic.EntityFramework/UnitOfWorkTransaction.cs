using System;
using System.Threading;
using Microsoft.EntityFrameworkCore.Storage;

namespace Toxic.EntityFramework
{
    public sealed class UnitOfWorkTransaction : IUnitOfWorkTransaction
    {
        private readonly IDbContextTransaction _transaction;

        internal UnitOfWorkTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public Guid TransactionId => _transaction.TransactionId;

        public void Commit()
        {
            _transaction.Commit();
        }

        public void CommitAsync(CancellationToken cancellationToken = default)
        {
            _transaction.CommitAsync(cancellationToken);
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }

        public void RollbackAsync(CancellationToken cancellationToken = default)
        {
            _transaction.RollbackAsync(cancellationToken);
        }
    }
}