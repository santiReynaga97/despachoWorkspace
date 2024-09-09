using ContpaqiNube.Despachos.Management.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ContpaqiNube.Despachos.Management.Api.Middlewares;

public class CustomExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomExceptionHandler> _logger;
    private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers;

    public CustomExceptionHandler(RequestDelegate next, ILogger<CustomExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
        // Register known exception types and handlers.
        _exceptionHandlers = new()
        {
            { typeof(Exception), HandleInternalException },
            { typeof(ValidationException), HandleValidationException },
            { typeof(NotFoundException), HandleNotFoundException },
            { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
            { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
        };
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {            
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            // Maneja la excepción usando tu lógica
            await TryHandleAsync(httpContext, ex, CancellationToken.None);
        }
    }

    private async Task HandleInternalException(HttpContext httpContext, Exception exception)
    {
        _logger.LogError(exception, "An unhandled exception occurred.");

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Internal Server Error",
            Detail = exception.Message, // Puedes omitir detalles en producción por seguridad
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        });
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var exceptionType = exception.GetType();

        if (_exceptionHandlers.ContainsKey(exceptionType))
        {
            await _exceptionHandlers[exceptionType].Invoke(httpContext, exception);
            return true;
        }

        // Si no hay un manejador específico, maneja como una excepción interna
        await HandleInternalException(httpContext, exception);
        return true;
    }

    private async Task HandleValidationException(HttpContext httpContext, Exception ex)
    {
        _logger.LogInformation("HandleValidationException", ex);
        var exception = (ValidationException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        await httpContext.Response.WriteAsJsonAsync(new ValidationProblemDetails(exception.Errors)
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        });
    }

    private async Task HandleNotFoundException(HttpContext httpContext, Exception ex)
    {
        _logger.LogInformation("HandleNotFoundException", ex);
        var exception = (NotFoundException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Status = StatusCodes.Status404NotFound,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found.",
            Detail = exception.Message
        });
    }

    private async Task HandleUnauthorizedAccessException(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Title = "Unauthorized",
            Type = "https://tools.ietf.org/html/rfc7235#section-3.1"
        });
    }

    private async Task HandleForbiddenAccessException(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status403Forbidden,
            Title = "Forbidden",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
        });
    }
}
