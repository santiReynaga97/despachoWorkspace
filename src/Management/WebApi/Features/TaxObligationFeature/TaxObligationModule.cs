using DespachoWorkspace.Management.WebApi.Abstractions;
using DespachoWorkspace.Management.WebApi.Features.TaxObligationFeature.Endpoints;

namespace DespachoWorkspace.Management.WebApi.Features.TaxObligationFeature
{
    public class TaxObligationModule : IModule
    {
        private IMediator? _mediator;
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            new TaxObligationReadsEndpoint(_mediator!).RegisterRoute(endpoints);
            new TaxObligationWritesEndpoint(_mediator!).RegisterRoute(endpoints);

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
