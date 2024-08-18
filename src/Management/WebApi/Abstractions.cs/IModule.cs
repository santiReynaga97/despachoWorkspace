namespace DespachoWorkspace.Management.WebApi.Abstractions;

public interface IModule
{
    WebApplicationBuilder RegisterModule(WebApplicationBuilder builder);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}