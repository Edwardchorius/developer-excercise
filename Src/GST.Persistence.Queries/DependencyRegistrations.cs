using System;
using System.Collections.Generic;
using System.Text;
using GST.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Abstractions.Interfaces;

namespace GST.Persistence.Queries
{
    public static class DependencyRegistrations
    {
        public static IServiceCollection RegisterFruitAndVegetablesPersistenceEfQueriesDependencies(
            this IServiceCollection services, string fruitAndVegetablesCommandDbConnectionString)
        {
            services.AddDbContext<ProductQueryContext>(c => c.UseSqlServer(fruitAndVegetablesCommandDbConnectionString));
            services.AddTransient(typeof(IReadableRepository<Product>), typeof(ProductEfReadRepository));

            return services;
        }
    }
}
