using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Exceptions;
using Persistence.Abstractions.Interfaces;

namespace Persistence.Commands.EF
{
    public abstract class CommandDbContext : DbContext
    {
        private ITransaction _currentTransaction;
        private bool _disposed;

        public CommandDbContext(DbContextOptions options)
            : base(options)
        {
            _disposed = false;
        }

        public bool HasActiveTransaction => _currentTransaction != null;

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override async Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            var now = DateTime.UtcNow;

            UpdateCreatedEntities(now);
            UpdateModifiedEntities(now);

            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            CheckIsDataSaved(result);

            return result;
        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            UpdateCreatedEntities(now);
            UpdateModifiedEntities(now);

            var result = base.SaveChanges();
            CheckIsDataSaved(result);

            return result;
        }

        public async Task BeginTransactionAsync()
        {
            if (HasActiveTransaction)
            {
                throw new Exception("There is active transaction that has not finished.");
            }

            _currentTransaction = new EfTransaction(await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted));
        }

        public async Task RollbackTransactionAsync()
        {
            if (HasActiveTransaction)
            {
                try
                {
                    await _currentTransaction.RollbackAsync();
                }
                finally
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task CommitAsync()
        {
            if (HasActiveTransaction == false)
            {
                throw new InvalidOperationException("Not current transaction.");
            }

            try
            {
                await SaveChangesAsync();
                await _currentTransaction.CommitAsync();
            }
            catch
            {
                await _currentTransaction.RollbackAsync();
                throw;
            }
            finally
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_disposed)
            {
                return;
            }

            if (isDisposing)
            {
                if (HasActiveTransaction)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }

            _disposed = true;

            base.Dispose();
        }

        private void CheckIsDataSaved(int result)
        {
            var boolResult = Convert.ToBoolean(result);
            if (boolResult == false)
            {
                throw new DataNotSavedException();
            }
        }

        private void UpdateCreatedEntities(DateTime time)
        {
            var entries = ChangeTracker
                .Entries<ICreatable>();

            var createdEntities = entries.Where(e => e.State == EntityState.Added);

            foreach (var entry in createdEntities)
            {
                entry.Property(nameof(IEntity.CreatedOn)).CurrentValue = time;
            }
        }

        private void UpdateModifiedEntities(DateTime time)
        {
            var entries = ChangeTracker
                .Entries<IModifiable>();

            var editedEntities = entries.Where(e => e.State == EntityState.Modified);

            foreach (var entry in editedEntities)
            {
                entry.Property(nameof(IEntity.ModifiedOn)).CurrentValue = time;
            }
        }
    }
}
