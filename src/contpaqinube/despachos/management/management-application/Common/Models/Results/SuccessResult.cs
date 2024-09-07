namespace ContpaqiNube.Despachos.Management.Application.Common.Models.Results;

public class SuccessResult : Result
{
    public SuccessResult(string message) : base(true, message)
    {
    }

    public SuccessResult(bool success) : base(true)
    {

    }
}