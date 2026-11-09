using FluentValidation;
using LinguaCommunity.Application.Dtos.Requests;
using LinguaCommunity.Application.Dtos.Responses;
using LinguaCommunity.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinguaCommunity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(AuthService authService): ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(IValidator<RegisterRequest> validator, RegisterRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        await authService.RegisterUser(request, cancellationToken);
        return Created();
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(IValidator<LoginRequest> validator, LoginRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var authResponse = await authService.LoginUser(request, cancellationToken);
        return Created("/api/auth/login", authResponse);
    }
}
