using LinguaCommunity.Infrastructure.Persistense;
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

        return services;
    }
}
