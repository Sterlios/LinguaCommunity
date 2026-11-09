namespace LinguaCommunity.Application.Dtos.Responses;

public record ArticlesItemResponse
(
    Guid Id,
    string Title,
    AuthorResponse Author,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);