using AspectCore.DynamicProxy;
using Serilog;
using System.Threading.Tasks;

namespace Toxic.EntityFramework
{
    public sealed class TransactionInterceptorAttribute : AbstractInterceptorAttribute
    {
        private readonly IUnitOfWork _dbUnitOfWork;

        public TransactionInterceptorAttribute(IUnitOfWork dbUnitOfWork)
        {
            _dbUnitOfWork = dbUnitOfWork;
        }

        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            using (var dbUnitOfWorkTransaction = await _dbUnitOfWork.BeginTransactionAsync())
            {
                try
                {
                    await next(context);
                    dbUnitOfWorkTransaction.Commit();
                }
                catch
                {
                    dbUnitOfWorkTransaction.RollBack();
                    Log.Warning(
                        $"An error occurred in the transaction\"{dbUnitOfWorkTransaction.TransactionId}\",the rollback has completed.");
                    throw;
                }
            }
        }
    }
}