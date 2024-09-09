using ContpaqiNube.Despachos.Management.Application.Common.Exceptions;
using ContpaqiNube.Despachos.Management.Application.Common.Models.Error;

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
            await TryHandleAsync(httpContext, ex, CancellationToken.None);
        }
    }
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var exceptionType = exception.GetType();

        if (_exceptionHandlers.ContainsKey(exceptionType))
        {
            await _exceptionHandlers[exceptionType].Invoke(httpContext, exception);
            return true;
        }

        await HandleInternalException(httpContext, exception);

        return true;
    }

    private async Task HandleInternalException(HttpContext httpContext, Exception exception)
    {
        _logger.LogError(exception, "An unhandled exception occurred.");

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var errorResponse = new ErrorResponse
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Internal Server Error",
            Detail = "An unexpected error occurred. Please try again later or contact support if the problem persists."
        };

        await httpContext.Response.WriteAsJsonAsync(errorResponse);
    }

    private async Task HandleValidationException(HttpContext httpContext, Exception ex)
    {
        _logger.LogInformation(ex, "HandleValidationException");

        var exception = (ValidationException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        var validationErrorResponse = new ValidationErrorResponse
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Validation Failed",
            Detail = "One or more validation errors occurred. Please check the provided data and try again."
        };

        foreach (var error in exception.Errors)
        {
            foreach (var fieldError in error.Value)
            {
                validationErrorResponse.Errors.Add(new ValidationErrorResponse.ValidationError
                {
                    Field = error.Key,
                    Message = fieldError
                });
            }
        }

        await httpContext.Response.WriteAsJsonAsync(validationErrorResponse);
    }

    private async Task HandleNotFoundException(HttpContext httpContext, Exception ex)
    {
        _logger.LogInformation(ex, "HandleNotFoundException");
        var exception = (NotFoundException)ex;

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        var errorResponse = new ErrorResponse
        {
            Status = StatusCodes.Status404NotFound,
            Title = "Resource Not Found",
            Detail = $"The requested resource could not be found. Please check the resource ID or endpoint."
        };

        errorResponse.Errors.Add(exception.Message);

        await httpContext.Response.WriteAsJsonAsync(errorResponse);
    }

    private async Task HandleUnauthorizedAccessException(HttpContext httpContext, Exception ex)
    {
        _logger.LogInformation(ex, "HandleUnauthorizedAccessException");

        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;

        var errorResponse = new ErrorResponse
        {
            Status = StatusCodes.Status401Unauthorized,
            Title = "Unauthorized",
            Detail = "You must be authenticated to access this resource. Please provide valid credentials."
        };

        errorResponse.Errors.Add("Access is denied due to invalid credentials.");

        await httpContext.Response.WriteAsJsonAsync(errorResponse);
    }

    private async Task HandleForbiddenAccessException(HttpContext httpContext, Exception ex)
    {
        _logger.LogInformation(ex, "HandleForbiddenAccessException occurred.");

        httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;

        var errorResponse = new ErrorResponse
        {
            Status = StatusCodes.Status403Forbidden,
            Title = "Forbidden",
            Detail = "You do not have permission to access this resource. Please contact your administrator if you believe this is an error."
        };

        errorResponse.Errors.Add("You do not have permission to access this resource.");

        await httpContext.Response.WriteAsJsonAsync(errorResponse);
    }
}
