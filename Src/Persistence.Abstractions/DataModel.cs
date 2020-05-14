using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions.Interfaces;

namespace Persistence.Abstractions
{
    public abstract class DataModel<TId> : IIdentifiable<TId>, ICreatable, IModifiable
    {
        public TId Id { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? ModifiedOn { get; private set; }

        public bool IsDeleted { get; private set; }

        public DateTime? DeletedOn { get; private set; }
    }
}
