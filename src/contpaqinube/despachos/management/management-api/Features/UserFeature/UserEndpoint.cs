using Result = ContpaqiNube.Despachos.Management.Application.Common.Models.Results;
using ContpaqiNube.Despachos.Management.Api.Abstractions;


namespace ContpaqiNube.Despachos.Management.Api.Features.UserFeature;

public class UserEndpoint : IEndpoint
{
    private readonly IMediator _mediator;

    public UserEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IEndpointRouteBuilder RegisterRoute(IEndpointRouteBuilder endpoints)
    {
        var blogGroup = endpoints.MapGroup("/api/users");

        blogGroup.MapGet("/", SyncUsers)
            .WithName("sync")
            .WithDisplayName("User Endpoints")
            .WithTags("users")
            .Produces<Result.SuccessDataResult<bool>>()
            .Produces(500);

        return blogGroup;
    }

    private async Task<IResult> SyncUsers()
    {
        return TypedResults.Ok(true);
    }
}