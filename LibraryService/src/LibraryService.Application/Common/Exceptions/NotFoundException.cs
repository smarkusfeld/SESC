using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Exceptions
{
    public abstract class NotFoundException : CustomException
    {
        protected NotFoundException(string message, List<string>? errors = default) : base(message, errors, HttpStatusCode.NotFound)
        { }
    }
    public sealed class NotFoundGeneralException : NotFoundException
    {
        public NotFoundGeneralException(string message, List<string>? errors = default)
            : base(message, errors)
        { }
    }
    public sealed class BadKeyException : NotFoundException
    {
        public BadKeyException(string name, string identifier)
            : base($"The {name} with the identifier {identifier} was not found.", null)
        { }
    }
    public sealed class NoRecordsFoundException : NotFoundException
    {
        public NoRecordsFoundException(string name)
            : base($"Not Found Error. No {name} records exists in the database.", null)
        { }
    }
    public sealed class NoRecordsMatchException : NotFoundException
    {
        public NoRecordsMatchException(string name, List<string>? errors = default)
            : base($"Not Found Error. No {name} records matching the query exists in the database.", errors)
        { }
    }
    public sealed class NoAvailableBookCopiesException : NotFoundException
    {
        public NoAvailableBookCopiesException(string title, string isbn, List<string>? errors = default)
            : base($"Not Found Error. No available copies found for ISBN: {isbn} Title: {title} ", errors)
        { }
    }


}
