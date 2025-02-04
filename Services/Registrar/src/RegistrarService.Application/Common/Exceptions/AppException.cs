using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

// custom exception class for throwing application specific exceptions 
public class AppException : Exception
{
    public AppException() : base() { }

    public AppException(string message) : base(message) { }

    public AppException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}