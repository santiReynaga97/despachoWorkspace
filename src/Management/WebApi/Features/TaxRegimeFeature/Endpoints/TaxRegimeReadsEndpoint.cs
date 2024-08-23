using Application.Features.TaxRegimeFeature.Queries;
using DespachoWorkspace.Management.Application.Common.Models.Error;
using DespachoWorkspace.Management.Application.Common.Models.Results;
using DespachoWorkspace.Management.Application.Features.TaxRegimeFeature.Queries;
using DespachoWorkspace.Management.WebApi.Abstractions;
using DespachoWorkspace.Management.WebApi.Filters;

using IResult = Microsoft.AspNetCore.Http.IResult;

namespace DespachoWorkspace.Management.WebApi.Features.TaxRegimeFeature.Endpoints
{
    public class TaxRegimeReadsEndpoint : IEndpoint
    {
        private readonly IMediator _mediator;

        public TaxRegimeReadsEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEndpointRouteBuilder RegisterRoute(IEndpointRouteBuilder endpoints)
        {
            var blogGroup = endpoints.MapGroup("/api/tax-regimes").AddEndpointFilter<ApiExceptionFilter>();

            blogGroup.MapGet("/", GetAllTaxRegimes)
                .WithName("GetAllTaxRegimes")
                .WithDisplayName("TaxRegime Reads Endpoints")
                .WithTags("TaxRegimes")
                .Produces<SuccessDataResult<List<GetAllTaxRegimesResponse>>>()
                .Produces(500);

            return blogGroup;
        }

        private async Task<IResult> GetAllTaxRegimes()
        {
            var blogs = await _mediator.Send(new GetAllTaxRegimesQuery());
            return TypedResults.Ok(blogs);
        }

    }
}