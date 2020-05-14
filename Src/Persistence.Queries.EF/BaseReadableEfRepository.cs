using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Interfaces;

namespace Persistence.Queries.EF
{
    public abstract class BaseReadableEfRepository<TEntity> : IReadableRepository<TEntity>
         where TEntity : class
    {
        protected readonly DbContext _readableDbContext;

        public BaseReadableEfRepository(DbContext readableDbContext)
        {
            _readableDbContext = readableDbContext;
        }

        //public async Task<TEntity> SingleOrDefaultAsync()
        //{

        //}

        //public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        //{
        //    return await _readableDbContext.Set<TEntity>().ToListAsync();
        //}

        //public async Task<bool> AnyAsync()
        //{
            
        //}
    }
}
