using System;
using Domain.Abstractions.Interfaces;

namespace Persistence.Abstractions.Models
{
    public abstract class DataModel<TId> : IIdentifiable<TId>, IEntity
    {
        public TId Id { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? ModifiedOn { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime? DeletedOn { get; private set; }
    }
}
