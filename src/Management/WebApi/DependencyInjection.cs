
//using DespachosMonorepWs.Management.Application.Common.Interfaces;
using DespachoWorkspace.Management.Infrastructure.Data;
//using DespachosMonorepWs.Management.Web.Infrastructure;
//using DespachosMonorepWs.Management.Web.Services;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
  public static IServiceCollection AddWebApiServices(this IServiceCollection services)
  {
    

    // services.AddScoped<IUser, CurrentUser>();

    // services.AddHttpContextAccessor();

    // services.AddExceptionHandler<CustomExceptionHandler>();

    // services.AddRazorPages();

    // // Customise default API behaviour
    // services.Configure<ApiBehaviorOptions>(options =>
    //     options.SuppressModelStateInvalidFilter = true);

    // services.AddEndpointsApiExplorer();

    //services.AddOpenApiDocument((configure, sp) =>
    //{
    //  configure.Title = "YourProjectName API";

    //  // Add JWT
    //  configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
    //  {
    //    Type = OpenApiSecuritySchemeType.ApiKey,
    //    Name = "Authorization",
    //    In = OpenApiSecurityApiKeyLocation.Header,
    //    Description = "Type into the textbox: Bearer {your JWT token}."
    //  });

    //  configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
    //});

    return services;
  }

  //public static IServiceCollection AddKeyVaultIfConfigured(this IServiceCollection services, ConfigurationManager configuration)
  //{
  //  var keyVaultUri = configuration["KeyVaultUri"];
  //  if (!string.IsNullOrWhiteSpace(keyVaultUri))
  //  {
  //    configuration.AddAzureKeyVault(
  //        new Uri(keyVaultUri),
  //        new DefaultAzureCredential());
  //  }

  //  return services;
  //}
}
