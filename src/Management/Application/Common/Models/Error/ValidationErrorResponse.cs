namespace DespachoWorkspace.Management.Application.Common.Models.Error;

public class ValidationErrorResponse: BaseErrorResponse
{
    public List<ValidationError> Errors { get; } = new List<ValidationError>();
    
    public class ValidationError
    {
        public string? PropertyName { get; set; }
        public string? ErrorMessage { get; set; }
    }
}