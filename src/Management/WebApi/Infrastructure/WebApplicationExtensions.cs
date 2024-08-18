
namespace DespachoWorkspace.Management.WebApi.Infrastructure;

public static class WebApplicationExtensions
{
  public static WebApplication ConfigureApplication(this WebApplication app)
  {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();

    return app;
  }
}