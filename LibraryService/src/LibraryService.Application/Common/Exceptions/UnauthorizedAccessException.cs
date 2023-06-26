using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Exceptions
{
    public abstract class  UnauthorizedAccessException : CustomException
    {
        protected UnauthorizedAccessException(string message, List<string>? errors = default)
            : base(message, errors, HttpStatusCode.Unauthorized) { }

       
    }
    public sealed class IncorrectPinException : UnauthorizedAccessException
    {
        public IncorrectPinException(string id)
           : base($"UnauthorizedAccess. Incorrect Pin for {id}") { }

    }
}
