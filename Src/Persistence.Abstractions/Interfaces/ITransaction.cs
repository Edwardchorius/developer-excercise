using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Abstractions.Interfaces
{
    public interface ITransaction : IDisposable
    {
        string Id { get; }

        Task CommitAsync();

        Task RollbackAsync();
    }
}
