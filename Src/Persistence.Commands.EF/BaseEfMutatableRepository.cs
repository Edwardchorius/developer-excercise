
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Interfaces;
using Persistence.Queries.EF;

namespace Persistence.Commands.EF
{
    public abstract class BaseEfMutatableRepository<TEntity>
        : BaseReadableEfRepository<TEntity>, IMutatableRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly CommandDbContext _commandDbContext;

        public BaseEfMutatableRepository(CommandDbContext dbContext)
            : base(dbContext)
        {
            _commandDbContext = dbContext;
        }

        public Task<TEntity> AddAsync(TEntity entity)
        {
            _commandDbContext.Set<TEntity>().Add(entity);

            return Task.FromResult(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _commandDbContext.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity)
        {
            _commandDbContext.Set<TEntity>().Remove(entity);

            return Task.CompletedTask;
        }

        public Task UpdateAllAsync(ICollection<TEntity> entities)
        {
            foreach (var entry in entities)
            {
                _commandDbContext.Entry(entry).State = EntityState.Modified;
            }            

            return Task.CompletedTask;
        }
    }
}
