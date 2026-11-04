using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaCommunity.Application.Exceptions;

public sealed class AccessDeniedException(Guid UserId, Guid articleId, string reason)
    : Exception($"Access denied for user with ID '{UserId}' and article with ID '{articleId}'. Reason: {reason}")
{
    public Guid UserId { get; } = UserId;
    public Guid ArticleId { get; } = articleId;
}
