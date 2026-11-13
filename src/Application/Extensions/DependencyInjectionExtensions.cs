using LinguaCommunity.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LinguaCommunity.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddScoped<ArticlesService>();
        builder.Services.AddScoped<TranslationService>();

        return builder;
    }
}
