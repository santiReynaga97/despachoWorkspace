using DespachoWorkspace.Management.WebApi.Abstractions;
using DespachoWorkspace.Management.WebApi.Features.TaxRegimeFeature.Endpoints;

namespace DespachoWorkspace.Management.WebApi.Features.TaxRegimeFeature
{
    public class TaxRegimeModule : IModule
    {
        private IMediator? _mediator;
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            new TaxRegimeReadsEndpoint(_mediator!).RegisterRoute(endpoints);
            return endpoints;
        }

        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();
            _mediator = provider.GetRequiredService<IMediator>();
            return builder;
        }
    }
}