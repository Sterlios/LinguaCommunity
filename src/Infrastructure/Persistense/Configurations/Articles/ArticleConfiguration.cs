using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Support;
using LinguaCommunity.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinguaCommunity.Infrastructure.Persistense.Configurations.Articles;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles", nameof(Schema.Articles));

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasConversion(
                id => id.Id,
                value => new ArticleId(value))
            .ValueGeneratedNever();

        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(a => a.Content)
            .IsRequired();

        builder.Property(a => a.Language)
            .IsRequired()
            .HasConversion(
                language => nameof(language),
                value => Enum.Parse<Language>(value));

        builder.Property(a => a.Version)
            .IsRequired();

        builder.Property(a => a.CreatedAt)
            .IsRequired();

        builder.Property(a => a.UpdatedAt)
            .IsRequired(false);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(a => a.AuthorId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
