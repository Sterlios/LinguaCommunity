using LinguaCommunity.Api.Handling;
using LinguaCommunity.Application.Extensions;
using LinguaCommunity.Infrastructure.Extensions;
using LinguaCommunity.Infrastructure.Persistense;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.EnvironmentName == "Local")
{
    builder.Configuration.AddUserSecrets<Program>();
}

if (!builder.Environment.IsProduction())
{
    builder.Services.AddSwaggerGen();// TODO: добавить авторизацию в Swagger
}

builder.Services.AddControllers();
builder.Services.AddLogging(); 
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.AddApplication();
builder.AddInfrastructure();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ArticlesContext>();
    dbContext.Database.Migrate();
}

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseAuthorization();
app.MapControllers();

app.Run();
