using Microsoft.AspNetCore.Identity;

namespace Classforce.Server.Entities;

/// <summary>
/// Represents a user account in the identity system.
/// </summary>
/// <remarks>
/// This is an internal database entity. Do not expose this type to clients.
/// </remarks>
public sealed class ApplicationUser : IdentityUser<Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationUser"/> class.
    /// </summary>
    public ApplicationUser() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationUser"/> class with the specified <paramref name="email"/> address.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="email"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="email"/> consists only of white-space characters.</exception>
    public ApplicationUser(string email) : base(email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email, nameof(email));
        Email = email;
    }

    /// <summary>
    /// Gets or sets the date and time when the user account was created.
    /// </summary>
    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets the collection of security sessions associated with this user.
    /// </summary>
    public ICollection<SecuritySession> SecuritySessions { get; } = null!;

    /// <summary>
    /// Gets the collection of email verifications associated with this user.
    /// </summary>
    public ICollection<EmailVerification> EmailVerifications { get; } = null!;

    public ICollection<OrganizationMembership> OrganizationMemberships { get; } = null!;

    public ICollection<GroupMembership> GroupMemberships { get; } = null!;

    public ICollection<DirectMessage> SentDirectMessages { get; } = null!;

    public ICollection<DirectMessage> ReceivedDirectMessages { get; } = null!;

    public ICollection<GroupMessage> SentGroupMessages { get; } = null!;

    public ICollection<IssueMessage> SentIssueMessages { get; } = null!;
}
