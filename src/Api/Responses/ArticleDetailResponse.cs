namespace LinguaCommunity.Api.Responses;

public record ArticleDetailResponse
(
    string Title,
    string Content,
    string AuthorName,
    DateTime CreatedAt,
    DateTime UpdatedAt
);