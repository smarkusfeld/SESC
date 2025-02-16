﻿using LibraryService.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace LibraryService.Portal.Middleware
{
    /// <summary>
    /// https://jasonwatmore.com/post/2022/01/17/net-6-global-error-handler-tutorial-with-example 
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case BadRequestException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case MySQLException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    case InvalidResponseException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadGateway;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
