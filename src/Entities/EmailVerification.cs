using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace Classforce.Server.Entities;

/// <summary>
/// Represents an email verification via a security code sent to the user inbox.
/// </summary>
/// <remarks>
/// This is an internal database entity. Do not expose this type to clients.
/// </remarks>
public sealed class EmailVerification
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmailVerification"/> class.
    /// </summary>
    public EmailVerification() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailVerification"/> class for the specified user.
    /// </summary>
    /// <param name="userId">The identifier of the user associated with this email verification.</param>
    [SetsRequiredMembers]
    public EmailVerification(Guid userId)
    {
        UserId = userId;
    }

    /// <summary>
    /// Gets or sets the unique identifier for this email verification.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets the unique identifier of the user associated with this email verification.
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// Gets the user associated with this email verification.
    /// </summary>
    public ApplicationUser User { get; } = null!;

    /// <summary>
    /// Gets or sets the secret code sent to the user inbox.
    /// </summary>
    public int SecurityCode { get; init; } = RandomNumberGenerator.GetInt32(0, 1000000);

    /// <summary>
    /// Gets or sets a flag indicating whether this email verification has been completed.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the email has been successfully confirmed, otherwise, <see langword="false"/>.
    /// </value>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time when this email verification was created.
    /// </summary>
    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;
}
