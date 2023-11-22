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
            return NotFound();
        }

        await verificationManager.CreateVerificationAsync(user.Id);
        return NoContent();
    }
}
