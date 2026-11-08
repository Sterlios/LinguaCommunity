using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Infrastructure.Authentication;
using LinguaCommunity.Infrastructure.Persistense;
using LinguaCommunity.Infrastructure.Persistense.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LinguaCommunity.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IUnitOfWork, ArticlesContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
        });

        builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IArticlesRepository, ArticlesRepository>();
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
        builder.Services.AddScoped<ITokenService, JwtTokenGenerator>();

        builder.Configuration.Bind("JwtOptions", new JwtOptions(
            SecretKey: builder.Configuration["JwtOptions:SecretKey"]
                ?? throw new InvalidOperationException("JwtOptions:SecretKey is not configured"),
            Issuer: builder.Configuration["JwtOptions:Issuer"]
                ?? throw new InvalidOperationException("JwtOptions:Issuer is not configured"),
            Audience: builder.Configuration["JwtOptions:Audience"]
                ?? throw new InvalidOperationException("JwtOptions:Audience is not configured"),
            ExpirationMinutes: int.Parse(builder.Configuration["JwtOptions:ExpirationMinutes"] ?? "60")
        ));

        return builder;
    }
}
