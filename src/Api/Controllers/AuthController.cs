using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Controllers;

//TODO: Add validation for RegisterRequest and LoginRequest using FluentValidation 

[Route("api/[controller]")]
[ApiController]
public class AuthController(AuthService authService): ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
    {
        await authService.RegisterUser(request, cancellationToken);
        return Created();
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var authResponse = await authService.LoginUser(request, cancellationToken);
        return Created("/api/auth/login", authResponse);
    }
}
