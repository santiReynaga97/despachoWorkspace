using DespachoWorkspace.Management.WebApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebApiServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

// Mapear controladores
app.MapControllers();
// app.UseExceptionHandler(options => { });
//app.Map("/", () => Results.Redirect("/api"));
//app.MapEndpoints();

app.Run();