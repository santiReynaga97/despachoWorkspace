using DespachoWorkspace.Management.WebApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebApiServices(builder);

builder.RegisterModules();

var app = builder.Build();
app.ConfigureApplication();

app.MapEndpoints();

app.Run();