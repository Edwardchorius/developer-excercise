using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstractions.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException()
        {
        }

        public ApplicationException(string propertyName, string message)
            : base(message)
        {
            PropertyName = propertyName;
        }

        public ApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public string PropertyName { get; private set; }
    }
}
