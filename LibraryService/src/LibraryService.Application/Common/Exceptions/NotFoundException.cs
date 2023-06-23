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
        protected NotFoundException(string message) : base(message, null, HttpStatusCode.NotFound)
        { }
    }
    public sealed class BadKeyException : NotFoundException
    {
        public BadKeyException(string name, string identifier)
            : base($"The {name} with the identifier {identifier} was not found.")
        { }

}
