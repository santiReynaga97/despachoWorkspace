namespace ContpaqiNube.Despachos.Management.Api.Abstractions
{
    public interface IEndpoint
    {
        IEndpointRouteBuilder RegisterRoute(IEndpointRouteBuilder endpoints);
    }
}
