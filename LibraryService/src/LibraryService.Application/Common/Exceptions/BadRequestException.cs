using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Exceptions
{
    public sealed class BadRequestException : CustomException
    {
        public BadRequestException(string message, List<string>? errors = default)
            : base(message, errors, HttpStatusCode.BadRequest) { }

        public BadRequestException(List<string>? errors = default)
            : base("Bad Request", errors, HttpStatusCode.BadRequest) { }
    }

    public sealed class InvalidRequestException : CustomException
    {
        public InvalidRequestException(string message, List<string>? errors = default)
           : base(message, errors, HttpStatusCode.BadRequest) { }

    }
    
}


