using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.ExceptionHandlingMiddleware.Models
{
    public class ValidationErrorResponse
    {
        public ValidationErrorResponse(string message, IReadOnlyDictionary<string, string[]> failures)
        {
            Message = message;
            Failures = failures?.SelectMany(n =>
                n.Value?.Select(v =>
                    new FailureResponse
                    {
                        Name = n.Key,
                        Reason = v,
                    }));
        }

        public ValidationErrorResponse(string message, IReadOnlyCollection<Failure> failures)
        {
            Message = message;
            Failures = failures?.Select(n => new FailureResponse { Name = n.Name, Reason = n.Reason });
        }

        public string Message { get; set; }

        public IEnumerable<FailureResponse> Failures { get; set; }
    }
}
