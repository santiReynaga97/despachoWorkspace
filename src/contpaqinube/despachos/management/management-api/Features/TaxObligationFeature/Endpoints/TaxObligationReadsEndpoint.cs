using ContpaqiNube.Despachos.Management.Application.Common.Models.Error;
using ContpaqiNube.Despachos.Management.Application.Common.Models.Results;
using ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Queries.GetAllTaxObligations;
using ContpaqiNube.Despachos.Management.Application.Features.TaxObligationFeature.Queries.GetTaxObligationById;
using ContpaqiNube.Despachos.Management.Api.Abstractions;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace ContpaqiNube.Despachos.Management.Api.Features.TaxObligationFeature.Endpoints
{
    public class TaxObligationReadsEndpoint : IEndpoint
    {
        private readonly IMediator _mediator;        
        private readonly ILogger<TaxObligationReadsEndpoint> _logger;

        public TaxObligationReadsEndpoint(IMediator mediator,         
          ILogger<TaxObligationReadsEndpoint> logger)
        {            
            _logger = logger;
            _mediator = mediator;
        }

        public IEndpointRouteBuilder RegisterRoute(IEndpointRouteBuilder endpoints)
        {
            var blogGroup = endpoints.MapGroup("/api/tax-obligations");

            blogGroup.MapGet("/", GetAllTaxObligations)
                .WithName("GetAllTaxObligations")
                .WithDisplayName("TaxObligation Reads Endpoints")
                .WithTags("TaxObligations")
                .Produces<SuccessDataResult<List<GetAllTaxObligationsResponse>>>()
                .Produces(500);

            blogGroup.MapGet("/{id}", GetTaxObligationById)                
                .WithName("GetTaxObligationById")
                .WithDisplayName("TaxObligation Reads Endpoints")
                .WithTags("TaxObligations")
                .Produces<SuccessDataResult<GetAllTaxObligationsResponse>>(200)
                .Produces<ErrorResponse>(404)
                .Produces<ErrorResponse>(500);

            // blogGroup.MapGet("/{id}/contributors", GetBlogContributors)
            //     .AddEndpointFilter<GuidValidationFilter>()
            //     .WithName("GetBlogContributors")
            //     .WithDisplayName("Blog Reads Endpoints")
            //     .WithTags("Blogs")
            //     .Produces<SuccessDataResult<List<GetBlogContributorsResponse>>>(200)
            //     .Produces(500)
            //     .Produces<ErrorResponse>(404)
            //     .Produces<ErrorResponse>(500);

            return blogGroup;
        }

        private async Task<IResult> GetAllTaxObligations()
        {
            var blogs = await _mediator.Send(new GetAllTaxObligationsQuery());
            return TypedResults.Ok(blogs);
        }
        private async Task<IResult> GetTaxObligationById(string id)
        {
            var blog = await _mediator.Send(new GetTaxObligationByIdQuery(Guid.Parse(id)));
            return TypedResults.Ok(blog);
        }

        // private async Task<IResult> GetBlogContributors(string id)
        // {
        //     var result = await _mediator.Send(new GetBlogContributorsQuery(Guid.Parse(id)));
        //     return TypedResults.Ok(result);
        // }
    }
}