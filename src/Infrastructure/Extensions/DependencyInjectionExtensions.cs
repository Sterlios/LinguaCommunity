using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Infrastructure.Persistense;
using LinguaCommunity.Infrastructure.Persistense.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LinguaCommunity.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ArticlesContext>(options =>
        {
            options.UseNpgsql("Postgres");
        });

        services.AddScoped<IArticlesRepository,ArticlesRepository>();
        services.AddScoped<IUsersRepository,UsersRepository>();

        return services;
    }
}
