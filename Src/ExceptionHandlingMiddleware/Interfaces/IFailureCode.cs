using System;
using System.Collections.Generic;
using System.Text;

namespace Web.ExceptionHandlingMiddleware.Interfaces
{
    public interface IFailureCode
    {
        int Value { get; }

        string Name { get; }
    }
}
