using DespachoWorkspace.Management.WebApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebApiServices();
builder.Services.AddSwaggerGen();


// Configurar proveedores de logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Configurar nivel mínimo de logging
builder.Logging.SetMinimumLevel(LogLevel.Information);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
// app.UseExceptionHandler(options => { });
//app.Map("/", () => Results.Redirect("/api"));
//app.MapEndpoints();

app.Run();