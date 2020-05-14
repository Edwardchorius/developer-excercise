using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Abstractions.Exceptions
{
    public class DataNotSavedException : Exception
    {
        public DataNotSavedException()
        {

        }

        public DataNotSavedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
