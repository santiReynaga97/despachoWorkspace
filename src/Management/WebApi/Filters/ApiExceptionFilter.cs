
using DespachoWorkspace.Management.Application.Common.Exceptions;
using DespachoWorkspace.Management.Application.Common.Models.Error;



namespace DespachoWorkspace.Management.WebApi.Filters;

public class ApiExceptionFilter:IEndpointFilter
{
    private readonly IDictionary<Type, Func<Exception, IResult>?> _exceptionHandlers;
    public ApiExceptionFilter()
    {
        _exceptionHandlers = new Dictionary<Type, Func<Exception, IResult>?>
        {
            { typeof(ValidationException), HandleValidationException },
            { typeof(NotFoundException), HandleNotFoundException },            
        };
    }
    
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        try
        {
            return await next(context);
        }
        catch (Exception ex)
        {
            return HandleException(ex);
        }
    }
    
    private IResult HandleException(Exception exception)
    {
        var type = exception.GetType();
        if (_exceptionHandlers.TryGetValue(type, out Func<Exception, IResult>? value))
        {
            return value!.Invoke(exception);
        }

        return HandleUnhandledException(exception);

    }
    
    private static IResult HandleUnhandledException(Exception ex)
    {
        var response =  new ErrorResponse
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            StatusPhrase = "Internal Server Error",
            Timestamp = DateTime.Now,
            Errors = { ex.Message }
        };
        
        return TypedResults.Json(response,statusCode:StatusCodes.Status500InternalServerError);
    }
    private static IResult HandleValidationException(Exception ex)
    {
        var exception = (ValidationException)ex;
        var response = exception.ValidationErrorResponse;
        
        return TypedResults.UnprocessableEntity(response);
    }
    
    private static IResult HandleNotFoundException(Exception ex)
    {
        var exception = (NotFoundException)ex;
        var response =  new ErrorResponse
        {
            StatusCode = StatusCodes.Status404NotFound,
            StatusPhrase = "Not Found",
            Timestamp = DateTime.Now,
            Errors = { exception.Message }
        };

        return TypedResults.NotFound(response);
    }

    
}