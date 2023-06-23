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
        public NotImplementedException(string message, List<string>? errors = default)
           : base(message, errors, HttpStatusCode.NotImplemented) { }

        public NotImplementedException(List<string>? errors = default)
            : base("Sever does not support the requested function", errors, HttpStatusCode.NotImplemented) { }
    }
}
