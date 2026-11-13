using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(UsersService usersService): ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> ChangeRole(UserChangeRole request, CancellationToken cancellationToken)
    {
        var authorId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ?? Guid.Empty.ToString());

        if (authorId == request.UserId)
            return Unauthorized("You cannot change your own role.");

        await usersService.ChangeRole(request, cancellationToken);
        return Ok();
    }
}
