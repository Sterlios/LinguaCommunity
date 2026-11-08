using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Infrastructure.Authentication;
using LinguaCommunity.Infrastructure.Persistense;
using LinguaCommunity.Infrastructure.Persistense.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LinguaCommunity.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IUnitOfWork, ArticlesContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

        builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
        builder.Services.AddScoped<IArticlesRepository, ArticlesRepository>();
        builder.Services.AddScoped<IUsersRepository, UsersRepository>();
        builder.Services.AddScoped<ITokenService, JwtTokenGenerator>();

        builder.Services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                options.MapInboundClaims = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
                    ValidAudience = builder.Configuration["JwtOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"]!)),
                    ClockSkew = TimeSpan.Zero
                };
            });

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
