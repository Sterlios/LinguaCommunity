using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Support;
using TaskStatus = LinguaCommunity.Domain.Models.Support.TaskStatus;

namespace LinguaCommunity.Domain.Models.Translations;

public record struct TranslationId(Guid Id);

public class Translation
{
    public TranslationId Id { get; } = new TranslationId(Guid.CreateVersion7());
    public ArticleId ArticleId { get; }
    public int SourceVersion { get; }
    public LanguageId LanguageId { get; }
    public TaskStatus Status { get; private set; } = TaskStatus.Pending;
    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;
    public int Version { get; private set; } = 1;
    public int RetryCount { get; private set; } = 0;
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public DateTime? NextTryAt { get; private set; }

    private Translation() { }

    public Translation(Article article, LanguageId languageId)
    {
        ArticleId = article.Id;
        SourceVersion = article.Version;
        LanguageId = languageId;
    }
}