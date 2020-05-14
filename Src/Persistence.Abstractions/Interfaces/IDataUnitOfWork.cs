
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Abstractions.Interfaces
{
    public interface IDataUnitOfWork
    {
        bool HasActiveTransaction { get; }

        Task BeginTransactionAsync();

        Task RollbackTransactionAsync();

        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
