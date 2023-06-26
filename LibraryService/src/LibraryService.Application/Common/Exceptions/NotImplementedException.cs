using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Exceptions
{
    public sealed class NotImplementedException : CustomException
    {
        public NotImplementedException(string message = "Server does not currently support the functionality required to fulfill the request", List<string>? errors = default)
            : base(message, errors, HttpStatusCode.NotImplemented)
        { }
    }
}
