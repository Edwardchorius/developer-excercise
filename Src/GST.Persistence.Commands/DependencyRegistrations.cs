using System;
using System.Collections.Generic;
using System.Text;
using GST.Persistence.Commands.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Abstractions.Interfaces;

namespace GST.Persistence.Commands
{
    public static class DependencyRegistrations
    {
        public static IServiceCollection RegisterFruitAndVegetablesPersistenceEfCommandsDependencies(
            this IServiceCollection services, string fruitAndVegetablesCommandDbConnectionString)
        {
            services.AddDbContext<ProductCommandContext>(c => c.UseSqlServer(fruitAndVegetablesCommandDbConnectionString));
            services.AddTransient(typeof(IMutatableRepository<>), typeof(ProductEfRepository<>));

            return services;
        }
    }
}
