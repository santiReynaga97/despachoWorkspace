using ContpaqiNube.Despachos.Management.Application.Common.Models.Error;
using FluentValidation.Results;

namespace ContpaqiNube.Despachos.Management.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationErrorResponse? ValidationErrorResponse { get; set; }

    public IDictionary<string, string[]> Errors { get; }

    public ValidationException()
        : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
        ValidationErrorResponse = new ValidationErrorResponse
        {
            Status = 422,
            Title = "Bad request",
            Detail = "One or more validation errors have occurred. Please check the request data."
        };
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        ValidationErrorResponse = GenerateErrorResponse(failures.ToList());
    }

    private static ValidationErrorResponse GenerateErrorResponse(List<ValidationFailure> failures)
    {
        var apiError = new ValidationErrorResponse
        {
            Status = 422,
            Title = "Bad request",
            Detail = "One or more validation errors have occurred. Please verify the provided fields.",
        };
        failures.ForEach(e => apiError.Errors.Add(new ValidationErrorResponse.ValidationError
        {
            Field = e.PropertyName.ToLower(),
            Message = e.ErrorMessage
        }));
        return apiError;
    }
}
