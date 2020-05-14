

namespace Domain.Abstractions.Interfaces
{
    public interface IEntity<TId> : IEntity, IIdentifiable<TId>
    {
    }

    public interface IEntity : ICreatable, IModifiable, IDeletable
    {
    }
}
