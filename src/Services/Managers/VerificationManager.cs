using Classforce.Server.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Classforce.Server.Services.Managers;

/// <summary>
/// Service responsible for performing email address verification process.
/// </summary>
/// <param name="context">The database context.</param>
/// <param name="userManager">The user manager.</param>
/// <param name="emailService">The email service.</param>
public sealed class VerificationManager(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailService emailService)
{
    /// <summary>
    /// Begins a new verification and emails the security code to the specified user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    /// <exception cref="InvalidOperationException">Thrown when the user is not found in the database.</exception>
    public async Task CreateVerificationAsync(Guid userId)
    {
        var user = await userManager.FindByIdAsync(userId.ToString()) ?? throw new InvalidOperationException($"User '{userId}' was not found.");
        if (string.IsNullOrWhiteSpace(user.Email))
        {
            throw new InvalidOperationException($"User '{userId}' does not have an email address.");
        }

        var verification = new EmailVerification(userId);

        _ = await context.EmailVerifications.AddAsync(verification);
        await emailService.SendVerificationCodeAsync(user.Email!, verification.SecurityCode);
    }

    /// <summary>
    /// Checks if the provided verification code is valid for the specified user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="verificationCode">The verification code provided by the user.</param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation, containing the result of the operation.
    /// <see langword="true"/> if the verification code is valid, otherwise <see langword="false"/>.
    /// </returns>
    public async Task<bool> CheckVerificationCodeAsync(Guid userId, int verificationCode)
    {
        var verification = await context.EmailVerifications
           .AsNoTracking()
           .Where(v => v.UserId == userId && v.SecurityCode == verificationCode)
           .OrderByDescending(v => v.CreationTime)
           .FirstOrDefaultAsync();

        return verification != null && !verification.IsCompleted && verification.CreationTime > DateTimeOffset.UtcNow.AddMinutes(-15);
    }
}
