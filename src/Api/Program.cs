using LinguaCommunity.Api.Handling;
using LinguaCommunity.Application.Extensions;
using LinguaCommunity.Infrastructure.Extensions;
using LinguaCommunity.Infrastructure.Persistense;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.EnvironmentName == "Local")
{
    builder.Configuration.AddUserSecrets<Program>();
}

if (!builder.Environment.IsProduction())
{
    builder.Services.AddSwaggerGen(c =>
    {
        var securityScheme = new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Description = "Enter 'Bearer {token}'",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
        };

        c.AddSecurityDefinition("bearer", securityScheme);
        c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
        {
            [new OpenApiSecuritySchemeReference("bearer", document)] = []
        });
    });
}

builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddAuthorization();

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

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
