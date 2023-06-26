using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Exceptions
{
    public sealed class InternalServerException : CustomException
    {
        public InternalServerException(string message, List<string>? errors = default)
            : base(message, errors, HttpStatusCode.InternalServerError) { }

        public InternalServerException(List<string>? errors = default)
            : base("Internal Server Error", errors, HttpStatusCode.InternalServerError) { }

        
    }
    public sealed class MysqlDataNullException : CustomException
    {
        public MysqlDataNullException(List<string>? errors = default)
            : base("Internal Server Error. Mysql Data is Null", errors, HttpStatusCode.InternalServerError) { }

    }
    public sealed class UnableToSaveRecordException : CustomException
    {
        public UnableToSaveRecordException(List<string>? errors = default)
            : base("Internal Server Error. An error occured while saving the record", errors, HttpStatusCode.InternalServerError) { }

    }

}
