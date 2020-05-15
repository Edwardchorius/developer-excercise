using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions.Interfaces;
using GST.Domain.Models;
using GST.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.Commands.EF;

namespace GST.Persistence.Commands.Repositories
{
    internal class ProductEfRepository<TEntity> : BaseEfMutatableRepository<TEntity>
        where TEntity : Entity, IEntity
    {
        public ProductEfRepository(
            ProductCommandContext commandContext)
            : base(commandContext)
        {

        }
    }
}
