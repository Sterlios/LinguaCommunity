using LinguaCommunity.Api.Authorization;
using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Requests.User;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(UsersService usersService): ControllerBase
{
    [HttpGet]
    public async Task<List<UserResponse>> GetUsers(PageParameters pageParameters, CancellationToken cancellationToken)
    {
        var users = await usersService.GetUsers(pageParameters, cancellationToken);
        return users;
    }

    [HttpPut]
    [Authorize(Policy = Policies.AdminOnly)]
    public async Task<IActionResult> ChangeRole(UserChangeRole request, CancellationToken cancellationToken)
    {
        var authorId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ?? Guid.Empty.ToString());

        if (authorId == request            return Forbid("You cannot change your own role.");

        await usersService.ChangeRole(request, cancellationToken);
        return Ok();
    }
}
