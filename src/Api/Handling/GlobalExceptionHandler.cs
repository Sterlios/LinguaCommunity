using LinguaCommunity.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Handling;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger): IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var (statusCode, title) = exception switch
        {
            ArticleNotFoundException =>
                (StatusCodes.Status404NotFound, "Article not found"),
            AccessDeniedException =>
                (StatusCodes.Status403Forbidden, "Access denied"),
            NicknameAlreadyExistsException =>
                (StatusCodes.Status409Conflict, "Nickname already exists"),
            EmailAlreadyExistsException =>
                (StatusCodes.Status409Conflict, "Email already exists"),
            InvalidLoginException =>
                (StatusCodes.Status401Unauthorized, "Invalid email or password."),
            _ =>
                (StatusCodes.Status500InternalServerError, "Internal server error")
        };

        logger.LogError(
            exception,
            "An exception occurred. TraceId: {TraceId}",
            context.TraceIdentifier); //TODO: если статус код 500, то логировать как ошибку. Если 404, 403, 409, 401 - логировать как предупреждение.

        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsJsonAsync(
            new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Instance = context.Request.Path,
                Extensions =
                {
                    ["traceId"] = context.TraceIdentifier
                }
            },
            cancellationToken);

        return true;
    }
}
