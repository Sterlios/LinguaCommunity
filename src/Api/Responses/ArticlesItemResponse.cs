namespace LinguaCommunity.Api.Responses;

public record ArticlesItemResponse
(
    string Title,
    AuthorResponse Author,
    DateTime CreatedAt,
    DateTime UpdatedAt
);