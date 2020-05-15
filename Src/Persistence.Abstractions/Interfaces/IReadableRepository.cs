using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Abstractions.Interfaces
{
    public interface IReadableRepository<TEntity>
        where TEntity : class
    {
        Task<IReadOnlyCollection<TEntity>> GetByNameAsync(string[] names);
    }
}
