using LinguaCommunity.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LinguaCommunity.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ArticlesService>();

        return services;
    }
}
