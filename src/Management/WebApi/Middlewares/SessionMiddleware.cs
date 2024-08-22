using DespachoWorkspace.Management.WebApi.Abstractions;

namespace DespachoWorkspace.Management.WebApi.Middlewares;

public class SessionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ISessionService _sessionService;

    private readonly string[] _whiteList = {
        "/weatherforecast",
        "/swagger",
        "favicon.ico"
    };

    public SessionMiddleware(RequestDelegate next, ISessionService sessionService)
    {
        _next = next;
        _sessionService = sessionService;
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

        if (currentPath.Contains("delegates"))
        {
            _sessionService.InitializeDelegates();
        }
        else
        {
            _sessionService.Initialize();
        }

        await _next(context);
    }
}
