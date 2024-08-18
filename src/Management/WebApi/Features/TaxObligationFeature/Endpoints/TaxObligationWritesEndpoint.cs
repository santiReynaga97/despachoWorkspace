using DespachoWorkspace.Management.Application.Common.Models.Error;
using DespachoWorkspace.Management.Application.Common.Models.Results;
using DespachoWorkspace.Management.Application.Features.TaxObligationFeature.Commands.CreateTaxObligation;
using DespachoWorkspace.Management.WebApi.Abstractions;
using DespachoWorkspace.Management.WebApi.Filters;
using IResult = Microsoft.AspNetCore.Http.IResult;


namespace DespachoWorkspace.Management.WebApi.Features.TaxObligationFeature.Endpoints
{
    public class TaxObligationWritesEndpoint : IEndpoint
    {
        private readonly IMediator _mediator;

        public TaxObligationWritesEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEndpointRouteBuilder RegisterRoute(IEndpointRouteBuilder endpoints)
        {
            var blogGroup = endpoints.MapGroup("/api/tax-obligations").AddEndpointFilter<ApiExceptionFilter>();

            blogGroup.MapPost("/", CreateTaxObligation)
                .AddEndpointFilter<GuidValidationFilter>()                
                .WithName("CreateTaxObligation")
                .WithDisplayName("TaxObligation Writes Endpoints")
                .WithTags("TaxObligations")
                .Produces<SuccessDataResult<CreateTaxObligationResponse>>(201)
                .Produces<ErrorResponse>(500);

            // blogGroup.MapPost("/{blogId}/contributors/{contributorId}",AddContributor)
            //     .AddEndpointFilter<GuidValidationFilter>()
            //     .WithName("Contributor")
            //     .WithDisplayName("Blog Writes Endpoints")
            //     .WithTags("Blogs")
            //     .Produces<SuccessResult>(200)
            //     .Produces<ErrorResponse>(404)
            //     .Produces<ErrorResponse>(500);

            // blogGroup.MapDelete("/{id}/contributors/{contributorId}", RemoveContributor)
            //     .AddEndpointFilter<GuidValidationFilter>()
            //     .WithName("RemoveContributor")
            //     .WithDisplayName("Blog Writes Endpoints")
            //     .WithTags("Blogs")
            //     .Produces<SuccessResult>(200)
            //     .Produces<ErrorResponse>(404)
            //     .Produces<ErrorResponse>(500);

            return blogGroup;
        }

        private async Task<IResult> CreateTaxObligation(CreateTaxObligationRequest taxObligation)
        {
            var command = new CreateTaxObligationCommand(taxObligation.Code, taxObligation.Description, taxObligation.IsActive, taxObligation.Name);
            var result = await _mediator.Send(command);
            return TypedResults.Ok(result);
        }

        // private async Task<IResult> AddContributor(string blogId, string contributorId)
        // {
        //     var result = await _mediator.Send(new AddContributorCommand(Guid.Parse(blogId),Guid.Parse(contributorId)));
        //     return TypedResults.Ok(result);
        // }

        // private async Task<IResult> RemoveContributor(string id, string contributorId)
        // {
        //     var result = await _mediator.Send(new RemoveContributorCommand(Guid.Parse(id), Guid.Parse(contributorId)));
        //     return TypedResults.Ok(result);
        // }
    }
}
