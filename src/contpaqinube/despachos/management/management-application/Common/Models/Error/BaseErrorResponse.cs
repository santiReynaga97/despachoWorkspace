namespace ContpaqiNube.Despachos.Management.Application.Common.Models.Error;

public class BaseErrorResponse
{
    public int StatusCode {get; set;}
    public string? StatusPhrase { get; set;}
    public DateTime Timestamp { get; set; }
}