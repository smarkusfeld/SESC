using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Exceptions
{
    
    public abstract class CustomException : Exception
    {
        public List<string>? Details { get; }
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// CustomException
        /// </summary>
        /// <param name="message">Exception Message</param>
        /// <param name="responseMessage">Reponse for controller</param>
        /// <param name="statusCode">Deafault Status code is internal service error</param>
        public CustomException(string message, List<string>? errors = default, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
                : base(message)
        {
            Details = details;
            StatusCode = statusCode;
        }
        

    }
}
