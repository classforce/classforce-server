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
    /// Initializes a new instance of the <see cref="ApplicationUser"/> class with the specified <paramref name="email"/> address.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    public ApplicationUser(string email) : base(email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email, nameof(email));
        Email = email;
    }

    /// <summary>
    /// Gets or sets the date and time when the user account was created.
    /// </summary>
    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;
}
