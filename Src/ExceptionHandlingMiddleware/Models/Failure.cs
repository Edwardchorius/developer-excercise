using System;
using System.Collections.Generic;
using System.Text;
using Web.ExceptionHandlingMiddleware.Interfaces;

namespace Web.ExceptionHandlingMiddleware.Models
{
    public class Failure
    {
        public Failure(string name, string reason, IFailureCode code)
        {
            Name = name;
            Reason = reason;
            Code = code;
        }

        public Failure(string name, string reason)
        {
            Name = name;
            Reason = reason;
        }

        public string Name { get; }

        public string Reason { get; }

        public IFailureCode Code { get; }

        public bool CodeIs(IFailureCode code)
        {
            var codesMatch = Code?.Equals(code) == true;

            return codesMatch;
        }
    }
}
