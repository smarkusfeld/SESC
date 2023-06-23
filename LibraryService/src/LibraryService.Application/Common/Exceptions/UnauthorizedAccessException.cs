using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Exceptions
{
    public sealed class  UnauthorizedAccessException : CustomException
    {
        public UnauthorizedAccessException(string message, List<string>? errors = default)
            : base(message, errors, HttpStatusCode.InternalServerError) { }

        public UnauthorizedAccessException(List<string>? errors = default)
            : base("Unauthorized Access", errors, HttpStatusCode.InternalServerError) { }
    }
}
