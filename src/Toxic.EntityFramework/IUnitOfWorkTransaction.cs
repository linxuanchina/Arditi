using System;

namespace Toxic.EntityFramework
{
    public interface IUnitOfWorkTransaction : IDisposable
    {
        Guid TransactionId { get; }

        void Commit();

        void RollBack();
    }
}