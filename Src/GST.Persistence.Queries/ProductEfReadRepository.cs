using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GST.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstractions.Interfaces;
using Persistence.Commands.EF;
using Persistence.Queries.EF;

namespace GST.Persistence.Queries
{
    internal class ProductEfReadRepository : IReadableRepository<Product>
    {
        private readonly ProductQueryContext _readableContext;
        public ProductEfReadRepository(
            ProductQueryContext queryContext)
        {
            _readableContext = queryContext;
        }

        public async Task<IReadOnlyCollection<Product>> GetByNameAsync(string[] names)
        {
            var result = new List<Product>();
            result.AddRange(_readableContext.Products.Where(k => names.Contains(k.Name)).ToList());
            return result;
        }
    }
}
