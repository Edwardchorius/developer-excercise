using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Abstractions.Interfaces
{
    public interface IReadableRepository<TEntity>
        where TEntity : class
    {
        //Task<TEntity> SingleOrDefaultAsync();
        //Task<IReadOnlyList<TEntity>> GetAllAsync();
        //Task<bool> AnyAsync();
    }
}
