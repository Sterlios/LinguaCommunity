using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
    {
        await authService.RegisterUser(request, cancellationToken);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        await authService.LoginUser(request, cancellationToken);
        return Ok();
    }
}
