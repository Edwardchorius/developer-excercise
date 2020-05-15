
using GST.Application.Commands;
using GST.Persistence.Commands;
using GST.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Abstractions.Interfaces;
using GST.Persistence.Queries;

namespace GST.Persistence
{
    public static class DependencyRegistrationsExtensions
    {
        public static IServiceCollection RegisterFruitAndVegetablesPersistenceDependencies(this IServiceCollection services, string fruitAndVegetablesCommandDbConnectionString)
        {
            services.RegisterFruitAndVegetablesPersistenceEfCommandsDependencies(fruitAndVegetablesCommandDbConnectionString);
            services.RegisterFruitAndVegetablesPersistenceEfQueriesDependencies(fruitAndVegetablesCommandDbConnectionString);

            services.AddTransient<IProductDataUnitOfWork, ProductUnitOfWork>();
            services.AddTransient<IDataUnitOfWork>(provider => provider.GetService<IProductDataUnitOfWork>());
            services.AddTransient<IDataSeedingService, DataSeedingService>();

            return services;
        }
    }
}
