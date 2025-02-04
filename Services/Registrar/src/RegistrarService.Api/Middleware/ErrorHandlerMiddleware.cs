using Microsoft.AspNetCore.Mvc;
using RegistrarService.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace RegistrarService.Service.Middleware
{
    /// <summary>
    /// Exception service
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
                    case AppException:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case BadRequestException:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case MySQLException:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    case InvalidResponseException:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadGateway;
                        break;
                    case KeyNotFoundException:
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
