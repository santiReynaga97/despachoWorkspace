using ContpaqiNube.Despachos.Management.Api.Abstractions;

namespace ContpaqiNube.Despachos.Management.Api.Middlewares;

public class SessionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceScopeFactory _serviceScopeFactory;


    private readonly string[] _whiteList = {
        "/weatherforecast",
        "/swagger",
        "favicon.ico"
    };

    public SessionMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
    {
        _next = next;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task Invoke(HttpContext context)
    {
        string currentPath = context.Request.Path.ToString().ToLower();
        bool skipSession = _whiteList.Any(currentPath.Contains);

        if (context.Request.Method == "OPTIONS" || skipSession)
        {
            await _next(context);
            return;
        }
        // Crear un nuevo alcance para el servicio scoped
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var sessionService = scope.ServiceProvider.GetRequiredService<ISessionService>();

            if (currentPath.Contains("delegates"))
            {
                sessionService.InitializeDelegates();
            }
            else
            {
                sessionService.Initialize();
            }
        }

        await _next(context);
    }
}
