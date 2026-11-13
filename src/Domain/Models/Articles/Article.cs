using LinguaCommunity.Domain.Models.Support;
using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Domain.Models.Articles;

public record struct ArticleId(Guid Id);

public class Article
{
    public Article(UserId authorId, string title, string content, LanguageId languageId)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentException.ThrowIfNullOrEmpty(content);

        Id = new ArticleId(Guid.CreateVersion7());
        AuthorId = authorId;
        Title = title;
        Content = content;
        LanguageId = languageId;
    }

    public ArticleId Id { get; }
    public UserId AuthorId { get; }
    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;
    public LanguageId LanguageId { get; }
    public int Version { get; private set; } = 1;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }

    public void Update(string title, string content)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentException.ThrowIfNullOrEmpty(content);

        Title = title;
        Content = content;
        UpdatedAt = DateTime.UtcNow;
        Version++;
    }
}
