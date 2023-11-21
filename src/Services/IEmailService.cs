namespace Classforce.Server.Services;

/// <summary>
/// Service responsible for sending emails, including verification codes.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Sends the verification <paramref name="code"/> to the specified email address.
    /// </summary>
    /// <param name="recipient">The email address to send the code to.</param>
    /// <param name="code">The verification code.</param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    Task SendVerificationCodeAsync(string recipient, int code);
}
