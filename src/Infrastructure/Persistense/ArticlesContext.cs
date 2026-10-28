using LinguaCommunity.Application.Interfaces;
using LinguaCommunity.Infrastructure.Persistense.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaCommunity.Infrastructure.Persistense;

public class ArticlesContext(DbContextOptions<ArticlesContext> options) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyMarker).Assembly);
    }
}
