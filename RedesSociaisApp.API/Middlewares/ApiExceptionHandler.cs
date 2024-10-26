using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using RedesSociaisApp.Application.Exceptions;

namespace RedesSociaisApp.API.Middlewares;

    public class ApiExceptionHandler(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        List<string> errors = new List<string>();
        HttpStatusCode statusCode;
        
        if (exception is AppException appException)
        {
            errors.AddRange(appException.Errors);
            statusCode = HttpStatusCode.BadRequest;
        }
        else
        {
            errors.Add(exception.Message);
            statusCode = HttpStatusCode.InternalServerError;
        }
        
        var response = new
        {
            errors = errors,
            status = statusCode
        };
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}

public static class ErrorMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiExceptionHandler>();
    }
}
