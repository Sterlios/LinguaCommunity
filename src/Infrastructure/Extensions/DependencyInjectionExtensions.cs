using LinguaCommunity.Application.Interfaces;
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
        builder.Services.AddDbContext<IUnitOfWork,ArticlesContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
        });

        builder.Services.AddScoped<IArticlesRepository,ArticlesRepository>();
        builder.Services.AddScoped<IUsersRepository,UsersRepository>();

        return builder;
    }
}
