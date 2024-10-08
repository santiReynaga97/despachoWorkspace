namespace ContpaqiNube.Despachos.Management.Application.Common.Models.Error;

public class ValidationErrorResponse : BaseErrorResponse
{
    public List<ValidationError> Errors { get; } = new List<ValidationError>();

    public class ValidationError
    {
        public string? Field { get; set; }
        public string? Message { get; set; }
    }
}