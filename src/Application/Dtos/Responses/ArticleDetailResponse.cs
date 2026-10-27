namespace LinguaCommunity.Application.Dtos.Responses;

public record ArticleDetailResponse
(
    string Title,
    string Content,
    AuthorResponse Author,
    DateTime CreatedAt,
    DateTime UpdatedAt
);