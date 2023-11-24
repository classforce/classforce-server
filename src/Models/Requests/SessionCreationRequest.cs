using System.ComponentModel.DataAnnotations;

namespace Classforce.Server.Models.Requests;

/// <summary>
/// Represents a user's request to create a session.
/// </summary>
public sealed record SessionCreationRequest
{
    /// <summary>
    /// Gets or sets the email address of the requesting user.
    /// </summary>
    [Required]
    [EmailAddress]
    public required string Email { get; init; }

    /// <summary>
    /// Gets or sets the verification code provided by the user.
    /// </summary>
    [Required]
    [Range(0, 999999)]
    public required int Code { get; init; }
}
