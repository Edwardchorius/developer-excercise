
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstractions.Interfaces;

namespace Persistence.Abstractions.Interfaces
{
    public interface IMutatableRepository<TEntity> : IReadableRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);
        Task UpdateAllAsync(ICollection<TEntity> entities);

        Task DeleteAsync(TEntity entity);
    }
}
