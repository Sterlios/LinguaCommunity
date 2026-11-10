namespace LinguaCommunity.Application.Exceptions;

public sealed class AccessDeniedException(Guid userId, Guid articleId, string reason)
    : Exception($"Access denied for user with ID '{userId}' and article with ID '{articleId}'. Reason: {reason}")
{
    public Guid UserId { get; } = userId;
    public Guid ArticleId { get; } = articleId;
}
