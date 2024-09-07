using DespachoWorkspace.Management.WebApi.Abstractions;
using DespachoWorkspace.Management.WebApi.Features.TaxObligationFeature.Endpoints;
using DespachoWorkspace.Management.WebApi.Models;

namespace DespachoWorkspace.Management.WebApi.Features.TaxObligationFeature
{
    public class TaxObligationModule : IModule
    {
        private IMediator? _mediator;
        private CustomSessionModel? _session;

        private ILogger<TaxObligationReadsEndpoint>? _logger;
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            new TaxObligationReadsEndpoint(_mediator!, _session!, _logger!).RegisterRoute(endpoints);
            new TaxObligationWritesEndpoint(_mediator!).RegisterRoute(endpoints);

            return endpoints;
        }

        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();
            
            _mediator = provider.GetRequiredService<IMediator>();
            _session = provider.GetRequiredService<CustomSessionModel>();
            _logger = provider.GetRequiredService<ILogger<TaxObligationReadsEndpoint>>();

            return builder;
        }
    }
}
