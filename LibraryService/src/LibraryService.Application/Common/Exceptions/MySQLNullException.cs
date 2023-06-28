using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Exceptions
{
    public class MySQLNullException : Exception
    {
        public MySQLNullException() : base() { }

        public MySQLNullException(string message) : base(message) { }

        public MySQLNullException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}