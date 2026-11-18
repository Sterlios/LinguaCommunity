namespace LinguaCommunity.Application.Dtos.ReadModels;

public class ArticleReadModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public AuthorReadModel Author { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public LanguageReadModel Language { get; set; } = null!;
}