namespace DespachoWorkspace.Management.WebApi.Abstractions
{
    public interface IEndpoint
    {
        IEndpointRouteBuilder RegisterRoute(IEndpointRouteBuilder endpoints);
    }
}
