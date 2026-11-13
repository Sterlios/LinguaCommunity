using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Support;
using LinguaCommunity.Domain.Models.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinguaCommunity.Infrastructure.Persistense.Configurations.Articles;

public class TranslationConfiguration: IEntityTypeConfiguration<Translation>
{
    public void Configure(EntityTypeBuilder<Translation> builder)
    {
        builder.ToTable("Translations", nameof(Schema.Translations));

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasConversion(
                id => id.Id,
                value => new TranslationId(value))
            .ValueGeneratedNever();

        builder.Property(a => a.Title)
            .HasMaxLength(200);

        builder.HasOne<Language>()
            .WithMany()
            .HasForeignKey(a => a.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(a => a.Status)
            .IsRequired()
            .HasConversion(
                status => status.ToString(),
                value => Enum.Parse<Domain.Models.Support.TaskStatus>(value));

        builder.HasOne<Article>()
            .WithMany()
            .HasForeignKey(a => a.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(a => a.Version)
            .IsRequired();
    }
}
