using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
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

    public sealed class MissingParameterException : CustomException
    {
        public MissingParameterException(string message, List<string>? errors = default)
           : base(message, errors, HttpStatusCode.BadRequest) { }
    }

    public sealed class InvalidParameterException : CustomException
    {
        public InvalidParameterException(string message, List<string>? errors = default)
           : base(message, errors, HttpStatusCode.BadRequest) { }

    }
    public sealed class AccountAlreadyExistsException : CustomException
    {
        public AccountAlreadyExistsException(string id)
           : base($"Account already exists for {id}", null, HttpStatusCode.BadRequest) { }

    }
    
    public sealed class DataValidationException : CustomException
    {
        public DataValidationException(List<string>? errors = default)
           : base($"Bad Request", errors, HttpStatusCode.BadRequest) { }

    }
}


