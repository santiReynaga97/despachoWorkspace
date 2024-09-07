namespace ContpaqiNube.Despachos.Management.Application.Common.Models.Results;

public interface IDataResult<out T> : IResult
{
    T Data { get; }
}
