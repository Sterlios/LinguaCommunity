using LinguaCommunity.Domain.Models.Support;
using LinguaCommunity.Domain.Models.Translations;
using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Domain.Models.Articles;

public class Article
{
    private Article(){} // Required by EF

    public Article(UserId authorId, string title, string content, Language language)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentException.ThrowIfNullOrEmpty(content);

        Id = new ArticleId(Guid.CreateVersion7());
        AuthorId = authorId;
        Title = title;
        Content = content;
        Language = language;
    }

    public ArticleId Id { get; }
    public UserId AuthorId { get; }
    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;
    public Language Language { get; }
    public int Version { get; private set; } = 1;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; }

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
