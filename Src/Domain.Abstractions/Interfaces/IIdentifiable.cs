namespace Domain.Abstractions.Interfaces
{
    public interface IIdentifiable<TId>
    {
        TId Id { get; }
    }
}
