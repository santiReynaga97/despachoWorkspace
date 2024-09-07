using DespachoWorkspace.Management.Application.Common.Models.Error;
using FluentValidation.Results;

namespace DespachoWorkspace.Management.Application.Common.Exceptions;

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
            StatusCode = 422,
            StatusPhrase = "Bad request",
            Timestamp = DateTime.Now
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
            StatusCode = 422,
            StatusPhrase = "Bad request",
            Timestamp = DateTime.Now

        };
        failures.ForEach(e => apiError.Errors.Add(new ValidationErrorResponse.ValidationError
        {
            PropertyName = e.PropertyName.ToLower(),
            ErrorMessage = e.ErrorMessage
        }));
        return apiError;
    }
}
