using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Common.Exceptions
{
    public sealed class ApiFailureException : CustomException
    {
        /// <summary>
        /// CustomException
        /// </summary>
        /// <param name="message">Exception Message</param>
        /// <param name="responseMessage">Reponse for controller</param>
        /// <param name="statusCode">Http Status Code</param>
        public ApiFailureException(string message, List<string>? details = default, HttpStatusCode statusCode)
                : base(message, details, statusCode)
        {
           
        }

        
    }
}
