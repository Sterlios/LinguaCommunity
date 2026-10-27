namespace LinguaCommunity.Api.Responses;

public record ArticleDetailResponse
(
    string Title,
    string Content,
    AuthorResponse Author,
    DateTime CreatedAt,
    DateTime UpdatedAt
);