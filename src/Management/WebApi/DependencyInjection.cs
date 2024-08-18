using DespachoWorkspace.Management.Application.Common.Interfaces;
using DespachoWorkspace.Management.WebApi.Services;
using DespachoWorkspace.Management.WebApi.Infrastructure;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
  public static IServiceCollection AddWebApiServices(this IServiceCollection services, WebApplicationBuilder builder)
  {
    services.AddScoped<IUser, CurrentUser>();

    services.AddHttpContextAccessor();

    services.AddExceptionHandler<CustomExceptionHandler>();

    //services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version = "v1" });
      c.TagActionsBy(ta => new List<string> { ta.ActionDescriptor.DisplayName! });
    });


    return services;
  }
}
