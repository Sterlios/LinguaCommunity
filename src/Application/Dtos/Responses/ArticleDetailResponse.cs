namespace LinguaCommunity.Application.Dtos.Responses;

public record ArticleDetailResponse
(
    Guid Id,
    string Title,
    string Content,
    AuthorResponse Author,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);