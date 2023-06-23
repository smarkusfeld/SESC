using LibraryService.Application.Common.Exceptions;
using LibraryService.Application.Interfaces;
using LibraryService.Application.Models;
using System.Text.Json.Serialization;
using NLog.Fluent;
using Serilog.Context;
using System;
using System.Net;
using System.Text.Json;

namespace LibraryService.Api.Middleware
{
    /// <summary>
    /// </summary>
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleExceptionAsync(context, exception);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, CustomException exception)
        {           
            
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)exception.StatusCode;
           
            var response = new ErrorDetails
            {
                Message = exception.Message,
                Details = exception.Details

            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}