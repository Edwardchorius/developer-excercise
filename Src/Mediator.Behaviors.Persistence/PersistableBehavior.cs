using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mediator.Abstractions.Requests;
using MediatR;
using Persistence.Abstractions.Interfaces;

namespace Mediator.Behaviors.Persistence
{
    public class PersistableBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IDataUnitOfWork _data;

        public PersistableBehavior(IDataUnitOfWork data)
        {
            _data = data;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(!request.GetType().IsSubclassOf(typeof(Command<TResponse>)) || _data.HasActiveTransaction)
            {
                return await next();
            }

            try
            {
                await _data.BeginTransactionAsync();
                TResponse result = await next();
                await _data.CommitAsync();

                return result;
            }
            catch
            {
                await _data.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
