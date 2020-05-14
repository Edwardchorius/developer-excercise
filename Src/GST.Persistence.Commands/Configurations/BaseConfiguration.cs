using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions.Interfaces;
using Persistence.Commands.EF.Configurations;

namespace GST.Persistence.Commands.Configurations
{
    internal abstract class BaseConfiguration<TEntity> : BaseEntityConfiguration<TEntity, string>
        where TEntity : class, IEntity<string>
    {

    }
}
