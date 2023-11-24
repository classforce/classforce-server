using Classforce.Server.Constants;
using Classforce.Server.Entities;
using Classforce.Server.Models.Requests;
using Classforce.Server.Models.Results;
using Classforce.Server.Services.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Classforce.Server.Controllers;

/// <summary>
/// The controller responsible for user authentication, including email verification and session creation.
/// </summary>
/// <param name="userManager">The user manager service.</param>
/// <param name="verificationManager">The verification manager service.</param>
/// <param name="sessionManager">The session manager service.</param>
[ApiController]
[Route("api/auth")]
public sealed class AuthenticationController(
    UserManager<ApplicationUser> userManager,
    VerificationManager verificationManager,
    SessionManager sessionManager) : ApplicationController
{
    /// <summary>
    /// Initiates an email verification process and sends the verification code to the user's inbox.
    /// </summary>
    /// <param name="request">The request to create a verification, containing the user's email address.</param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation, containing the <see cref="IActionResult"/> of the request.
    /// </returns>
    /// <exception cref="InvalidOperationException">Thrown when an unexpected identity error occurrs.</exception>
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

    /// <summary>
    /// Creates a session for the user with the specified email address provided that the verification code is valid.
    /// </summary>
    /// <param name="request">The request to create a session, containg the email address along with verification code that will be checked.</param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation, containing the <see cref="ActionResult"/>,
    /// which will be <see cref="SessionCreationResult"/> if the session was created successfully.
    /// </returns>
    /// <remarks>
    /// The returned <see cref="SessionCreationResult"/> contains the refresh token that can be used to create access tokens.
    /// </remarks>
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
