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
    VerificationManager verificationManager) : ApplicationController
{
    [HttpPost("create-verification")]
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
}
