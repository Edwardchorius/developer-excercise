using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions.Interfaces;

namespace Domain.Abstractions.Models
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        private TId _id;

        public virtual TId Id
        {
            get => _id;
            private set
            {
                _id = value;
            }
        }

        public DateTime CreatedOn { get; protected set; }

        public DateTime? ModifiedOn { get; protected set; }

        public bool IsDeleted { get; protected set; }

        public DateTime? DeletedOn { get; protected set; }
    }
}
