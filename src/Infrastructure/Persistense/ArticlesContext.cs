using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Support;
using LinguaCommunity.Domain.Models.Translations;
using LinguaCommunity.Domain.Models.Users;
using LinguaCommunity.Infrastructure.Persistense.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LinguaCommunity.Infrastructure.Persistense;

public class ArticlesContext(DbContextOptions<ArticlesContext> options): DbContext(options), IUnitOfWork
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<Translation> Translations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Language> Languages { get; internal set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyMarker).Assembly);
    }
}
