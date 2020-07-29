using AspectCore.DynamicProxy;
using Serilog;
using System.Threading.Tasks;

namespace Toxic.EntityFramework
{
    public sealed class TransactionAttribute : AbstractInterceptorAttribute
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionAttribute(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            using (var dbUnitOfWorkTransaction = await _unitOfWork.BeginTransactionAsync())
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