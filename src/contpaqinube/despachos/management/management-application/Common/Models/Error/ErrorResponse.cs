namespace DespachoWorkspace.Management.Application.Common.Models.Error;

public class ErrorResponse:BaseErrorResponse
{
    public List<string> Errors { get; } = new List<string>();
}