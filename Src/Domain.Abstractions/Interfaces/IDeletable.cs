using System;


namespace Domain.Abstractions.Interfaces
{
    public interface IDeletable
    {
        bool IsDeleted { get; }
        DateTime? DeletedOn { get; }
    }
}
