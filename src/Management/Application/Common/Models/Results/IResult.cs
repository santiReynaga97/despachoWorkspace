namespace DespachoWorkspace.Management.Application.Common.Models.Results;

public interface IResult
{
    bool Success { get; }
    string Message { get; }
}