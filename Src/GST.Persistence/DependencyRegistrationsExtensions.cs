using System;
using System.Collections.Generic;
using System.Text;
using GST.Application.Commands;
using GST.Persistence.Commands;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Abstractions.Interfaces;

namespace GST.Persistence
{
    public static class DependencyRegistrationsExtensions
    {
        public static IServiceCollection RegisterFruitAndVegetablesPersistenceDependencies(this IServiceCollection services, string fruitAndVegetablesCommandDbConnectionString)
        {
            services.RegisterFruitAndVegetablesPersistenceEfCommandsDependencies(fruitAndVegetablesCommandDbConnectionString);

            services.AddTransient<IProductDataUnitOfWork, ProductUnitOfWork>();
            services.AddTransient<IDataUnitOfWork>(provider => provider.GetService<IProductDataUnitOfWork>());

            return services;
        }
    }
}
