using Microsoft.AspNetCore.Identity;

namespace Classforce.Server.Entities;

/// <summary>
/// Represents a user role in the identity system.
/// </summary>
/// <remarks>
/// This is an internal database entity. Do not expose this type to clients.
/// </remarks>
public sealed class ApplicationRole : IdentityRole<Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRole"/> class.
    /// </summary>
    public ApplicationRole() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationRole"/> class with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The name of the role.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> consists only of white-space characters.</exception>
    public ApplicationRole(string name) : base(name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
    }
}
