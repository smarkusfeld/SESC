using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.Application.Common.Exceptions
{
    // custom exception class for throwing application specific exceptions (e.g. for validation) 
    // that can be caught and handled within the application
    public class InvalidResponseException : Exception
    {
        public InvalidResponseException() : base() { }

        public InvalidResponseException(string message) : base(message) { }

        public InvalidResponseException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}