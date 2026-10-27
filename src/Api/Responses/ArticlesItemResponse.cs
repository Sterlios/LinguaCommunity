namespace LinguaCommunity.Api.Responses;

public record ArticlesItemResponse
(
    string Title,
    string AuthorName,
    DateTime CreatedAt,
    DateTime UpdatedAt
);