using LinguaCommunity.Domain.Models.Support;
using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Domain.Models.Articles;

public class Article
{
    public Article(UserId authorId, string title, string content, Language language)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentException.ThrowIfNullOrEmpty(content);

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

    public void Update(string title, string content)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        ArgumentException.ThrowIfNullOrEmpty(content);

        Title = title;
        Content = content;
        Version++;
    }

    public void UpdateContent(string content)
    {
        ArgumentException.ThrowIfNullOrEmpty(content);
        Content = content;
        Version++;
    }

    public void UpdateTitle(string title)
    {
        ArgumentException.ThrowIfNullOrEmpty(title);
        Title = title;
        Version++;
    }
}
