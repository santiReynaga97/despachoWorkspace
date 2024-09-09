namespace ContpaqiNube.Despachos.Management.Application.Common.Models.Error;

public class BaseErrorResponse
{
    public int Status {get; set;}
    public required string Title { get; set;}
    public DateTime Timestamp { get; } = DateTime.UtcNow;
    public required string Detail {get; set; }
}

