
using GST.Domain.Models;
using Persistence.Abstractions.Interfaces;

namespace GST.Application.Commands
{
    public interface IFruitAndVegetablesDataUnitOfWork : IDataUnitOfWork
    {
        IMutatableRepository<FruitAndVegetables> FruitAndVegetables { get; }
    }
}
