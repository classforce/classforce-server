using System.ComponentModel.DataAnnotations;

namespace Classforce.Server.Models.Requests;

/// <summary>
/// Represents a user's request to create an email verification.
/// </summary>
public sealed record VerificationCreationRequest
{
    /// <summary>
    /// Gets or sets the email address of the requesting user.
    /// </summary>
    /// <remarks>
    /// A verification code will be sent to this email when the request is processed.
    /// </remarks>
    [Required]
    [EmailAddress]
    public required string Email { get; init; }
}
