using ContpaqiNube.Despachos.Management.Api.Abstractions;

namespace ContpaqiNube.Despachos.Management.Api.Features.UserFeature;

public class UserModule : IModule
{
    private IMediator? _mediator;
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        new UserEndpoint(_mediator!).RegisterRoute(endpoints);

        return endpoints;
    }

    public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
    {
        var provider = builder.Services.BuildServiceProvider();
        _mediator = provider.GetRequiredService<IMediator>();
        return builder;
    }
}