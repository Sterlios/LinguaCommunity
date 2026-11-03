using System;
using System.Collections.Generic;
using System.Text;

namespace LinguaCommunity.Application.Exceptions;

public sealed class ArticleNotFoundException(Guid articleId) 
    : Exception($"Article with ID '{articleId}' was not found.")
{
    public Guid ArticleId { get; } = articleId;
}
