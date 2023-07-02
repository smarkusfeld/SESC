using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Exceptions
{
    public class MySQLException : Exception
    {
        public MySQLException() : base() { }

        public MySQLException(string message) : base(message) { }

        public MySQLException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}