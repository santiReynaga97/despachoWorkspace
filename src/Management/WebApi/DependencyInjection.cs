using DespachoWorkspace.Management.Application.Common.Interfaces;
using DespachoWorkspace.Management.WebApi.Services;
using DespachoWorkspace.Management.WebApi.Infrastructure;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
  public static IServiceCollection AddWebApiServices(this IServiceCollection services)
  {
    services.AddScoped<IUser, CurrentUser>();

    services.AddHttpContextAccessor();

    services.AddExceptionHandler<CustomExceptionHandler>();

    // // // Customise default API behaviour
    // services.Configure<ApiBehaviorOptions>(options =>
    //     options.SuppressModelStateInvalidFilter = true);

    // services.AddEndpointsApiExplorer();

    return services;
  }
}
