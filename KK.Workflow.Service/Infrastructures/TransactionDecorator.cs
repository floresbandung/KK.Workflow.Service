using System;
using System.Threading;
using System.Threading.Tasks;
using KK.Workflow.Service.DataContext;
using KK.Workflow.Service.Features;
using MediatR;

namespace KK.Workflow.Service.Infrastructures
{
    public class TransactionDecorator<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly WorkflowDataContext _dataContext;

        public TransactionDecorator(WorkflowDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var useTransaction = true;
            if (request is BaseRequest baseRequest) useTransaction = baseRequest.UseTransaction;
            if (useTransaction)
            {
                await using var transaction = await _dataContext.Database.BeginTransactionAsync(cancellationToken);
                try
                {
                    var response = await next();
                    await transaction.CommitAsync(cancellationToken);
                    return response;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    throw;
                }
            }
            var handle = await next();
            return handle;
        }
    }
}
