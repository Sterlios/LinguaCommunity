using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Support;
using TaskStatus = LinguaCommunity.Domain.Models.Support.TaskStatus;

namespace LinguaCommunity.Domain.Models.Translations;

public record struct TranslationId(Guid Id);

public class Translation(Article article, Language language)
{
    public TranslationId Id { get; } = new TranslationId(Guid.CreateVersion7());
    public ArticleId ArticleId { get; } = article.Id;
    public int SourceVersion { get; } = article.Version;
    public Language Language { get; } = language;
    public TaskStatus Status { get; private set; } = TaskStatus.Pending;
    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;
    public int Version { get; private set; } = 1;
    public int RetryCount { get; private set; } = 0;
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public DateTime? NextTryAt { get; private set; }
}