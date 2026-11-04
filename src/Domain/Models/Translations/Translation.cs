using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Support;
using LinguaCommunity.Domain.Models.Users;

namespace LinguaCommunity.Domain.Models.Translations;

public record struct TranslationId(Guid Id);

public class Translation
{
    public TranslationId Id { get; }
    public ArticleId ArticleId { get; }
    public int SourceVersion { get; }
    public Language Language { get; }
    public string Title { get; private set; } = null!;
    public string Content { get; private set; } = null!;
    public int Version { get; private set; } = 1;
}