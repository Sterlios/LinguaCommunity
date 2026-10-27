namespace LinguaCommunity.Application.Dtos.Responses;

public record ArticlesItemResponse
(
    string Title,
    AuthorResponse Author,
    DateTime CreatedAt,
    DateTime UpdatedAt
);