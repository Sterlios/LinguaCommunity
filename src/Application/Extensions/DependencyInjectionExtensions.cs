using LinguaCommunity.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LinguaCommunity.Application.Extensions;

public static class DependencyInjectionExtensions
{
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<ArticlesService>();

        return builder;
    }
}
