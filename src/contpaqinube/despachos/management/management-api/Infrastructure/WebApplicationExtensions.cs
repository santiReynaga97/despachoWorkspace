using ContpaqiNube.Despachos.Management.Api.Middlewares;

namespace ContpaqiNube.Despachos.Management.Api.Infrastructure;

public static class WebApplicationExtensions
{
  public static WebApplication ConfigureApplication(this WebApplication app)
  {
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();    
    app.UseMiddleware<CustomExceptionHandler>();

    return app;
  }
}