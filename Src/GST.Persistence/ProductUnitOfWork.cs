
using System.Threading;
using System.Threading.Tasks;
using GST.Application.Commands;
using GST.Domain.Models;
using GST.Persistence.Commands;
using Persistence.Abstractions.Interfaces;

namespace GST.Persistence
{
    internal class ProductUnitOfWork : IProductDataUnitOfWork
    {
        private readonly ProductCommandContext _commandContext;

        public ProductUnitOfWork(
            ProductCommandContext commandContext,
            IMutatableRepository<Product> products,
            IMutatableRepository<Deal> deals)
        {
            _commandContext = commandContext;
            Products = products;
            Deals = deals;
        }

        public IMutatableRepository<Product> Products { get; }
        public IMutatableRepository<Deal> Deals { get; }

        public bool HasActiveTransaction => _commandContext.HasActiveTransaction;

        public async Task BeginTransactionAsync()
        {
            await _commandContext.BeginTransactionAsync();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _commandContext.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _commandContext.RollbackTransactionAsync();
        }
    }
}
