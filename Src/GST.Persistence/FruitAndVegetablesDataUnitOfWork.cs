
using System.Threading;
using System.Threading.Tasks;
using GST.Application.Commands;
using GST.Domain.Models;
using GST.Persistence.Commands;
using Persistence.Abstractions.Interfaces;

namespace GST.Persistence
{
    internal class FruitAndVegetablesDataUnitOfWork : IFruitAndVegetablesDataUnitOfWork
    {
        private readonly FruitAndVegetablesCommandContext _commandContext;

        public FruitAndVegetablesDataUnitOfWork(
            FruitAndVegetablesCommandContext commandContext,
            IMutatableRepository<FruitAndVegetables> fruitAndVegetables)
        {
            _commandContext = commandContext;
            FruitAndVegetables = fruitAndVegetables;
        }

        public IMutatableRepository<FruitAndVegetables> FruitAndVegetables { get; }

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
