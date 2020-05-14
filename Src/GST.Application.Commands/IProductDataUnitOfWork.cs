
using GST.Domain.Models;
using Persistence.Abstractions.Interfaces;

namespace GST.Application.Commands
{
    public interface IProductDataUnitOfWork : IDataUnitOfWork
    {
        IMutatableRepository<Product> Products { get; }
    }
}
