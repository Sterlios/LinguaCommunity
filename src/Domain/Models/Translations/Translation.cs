using LinguaCommunity.Domain.Models.Articles;
using LinguaCommunity.Domain.Models.Support;

namespace LinguaCommunity.Domain.Models.Translations;

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