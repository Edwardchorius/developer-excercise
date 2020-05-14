using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions.Interfaces;
using GST.Domain.Models.Base;
using Persistence.Commands.EF;

namespace GST.Persistence.Commands.Repositories
{
    internal class FruitAndVegetablesEfRepository<TEntity> : BaseEfMutatableRepository<TEntity>
        where TEntity : Entity, IEntity
    {
        public FruitAndVegetablesEfRepository(
            FruitAndVegetablesCommandContext commandContext)
            : base(commandContext)
        {

        }
    }
}
