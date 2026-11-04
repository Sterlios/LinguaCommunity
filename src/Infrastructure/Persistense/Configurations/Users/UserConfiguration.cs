using LinguaCommunity.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinguaCommunity.Infrastructure.Persistense.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", nameof(Schema.Users));

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion(
                id => id.Id,
                value => new UserId(value))
            .ValueGeneratedNever();

        builder.Property(u => u.Email)
            .HasConversion(
                email => email.Value,
                value => new Email(value))
            .IsRequired()
            .HasMaxLength(256);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Nickname)
            .HasConversion(
                nickname => nickname.Value,
                value => new Nickname(value))
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(u => u.Nickname)
            .IsUnique();

        builder.Property(u => u.PasswordHash)
            .IsRequired();
    }
}
