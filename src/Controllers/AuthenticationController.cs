using Classforce.Server.Constants;
using Classforce.Server.Entities;
using Classforce.Server.Models;
using Classforce.Server.Services.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Classforce.Server.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthenticationController(
    UserManager<ApplicationUser> userManager,
    VerificationManager verificationManager,
    SessionManager sessionManager) : ApplicationController
{
    [HttpPost("send-code")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SendCodeAsync(VerificationCreationRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            user = new ApplicationUser(request.Email);

            var userCreationResult = await userManager.CreateAsync(user);
            if (!userCreationResult.Succeeded)
            {
                var error = userCreationResult.Errors.First();
                if (error.Code == "InvalidEmail")
                {
                    return ApiError(CommonApiErrors.InvalidEmail);
                }
                else
                {
                    throw new InvalidOperationException($"An unexpected identity error occurred: {error.Code}");
                }
            }
        }

        await verificationManager.CreateVerificationAsync(user.Id);
        return NoContent();
    }

    [HttpPost("create-session")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<SessionCreationResult>> CreateSessionAsync(SessionCreationRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return ApiError(CommonApiErrors.UnknownEmail);
        }

        var result = await verificationManager.CheckVerificationCodeAsync(user.Id, request.Code);
        if (!result)
        {
            return ApiError(CommonApiErrors.InvalidVerificationCode);
        }

        var session = new SecuritySession(user.Id);
        await sessionManager.CreateAsync(session);

        return Ok(new SessionCreationResult(session.RefreshToken));
    }
}
