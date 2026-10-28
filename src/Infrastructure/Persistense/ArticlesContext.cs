using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Users;
using LinguaCommunity.Infrastructure.Persistense.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaCommunity.Infrastructure.Persistense;

public class ArticlesContext(DbContextOptions<ArticlesContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyMarker).Assembly);
    }
}
