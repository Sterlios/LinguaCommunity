namespace LinguaCommunity.Application.Dtos.Responses;

public record ArticleDetailResponse
(
    Guid Id,
    string Title,
    string Content,
    LanguageResponse Language,
    AuthorResponse Author,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);