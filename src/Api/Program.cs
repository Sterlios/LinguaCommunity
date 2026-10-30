using LinguaCommunity.Application.Extensions;
using LinguaCommunity.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.EnvironmentName == "Local")
{
    builder.Configuration.AddUserSecrets<Program>();
}

if (!builder.Environment.IsProduction())
{
    builder.Services.AddSwaggerGen();
}

builder.Services.AddControllers();
builder.Services.AddLogging();

builder.AddApplication();
builder.AddInfrastructure();

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
