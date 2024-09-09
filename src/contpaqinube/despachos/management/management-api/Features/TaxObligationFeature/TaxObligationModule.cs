using ContpaqiNube.Despachos.Management.Api.Abstractions;
using ContpaqiNube.Despachos.Management.Api.Features.TaxObligationFeature.Endpoints;

namespace ContpaqiNube.Despachos.Management.Api.Features.TaxObligationFeature
{
    public class TaxObligationModule : IModule
    {
        private IMediator? _mediator;        

        private ILogger<TaxObligationReadsEndpoint>? _logger;
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            new TaxObligationReadsEndpoint(_mediator!, _logger!).RegisterRoute(endpoints);
            new TaxObligationWritesEndpoint(_mediator!).RegisterRoute(endpoints);

            return endpoints;
        }

        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();
            
            _mediator = provider.GetRequiredService<IMediator>();            
            _logger = provider.GetRequiredService<ILogger<TaxObligationReadsEndpoint>>();

            return builder;
        }
    }
}
