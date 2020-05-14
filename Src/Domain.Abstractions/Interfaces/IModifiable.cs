using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstractions.Interfaces
{
    public interface IModifiable
    {
        DateTime? ModifiedOn { get; }
    }
}
