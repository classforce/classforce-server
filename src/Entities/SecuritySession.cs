using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace Classforce.Server.Entities;

/// <summary>
/// Represents a persistant user authentication session.
/// </summary>
public sealed class SecuritySession
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SecuritySession"/> class.
    /// </summary>
    public SecuritySession() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SecuritySession"/> class for the specified user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user associated with this security session.</param>
    [SetsRequiredMembers]
    public SecuritySession(Guid userId)
    {
        UserId = userId;
    }

    /// <summary>
    /// Gets or sets the unique identifier of this security session.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets the unique identifier of the user associated with this security session.
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// Gets the user associated with this security session.
    /// </summary>
    public ApplicationUser User { get; } = null!;

    /// <summary>
    /// Gets or sets the last IP address associated with this security session.
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// Gets or sets the persistent refresh token used to generate temporary access tokens.
    /// </summary>
    public string RefreshToken { get; init; } = CreateRefreshToken();

    /// <summary>
    /// Gets or sets a flag indicating whether this security session can still be used to generate access tokens.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the session is valid and can be used to generate access tokens, otherwise, <see langword="false"/>.
    /// </value>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the date and time when this security session was created.
    /// </summary>
    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets or sets the date and time when this security session was last used to generate an access token.
    /// </summary>
    /// <remarks>
    /// Can be <see langword="null"/> if the session has never been used to create an access token.
    /// </remarks>
    public DateTimeOffset? LastSignInTime { get; set; }

    private static string CreateRefreshToken()
    {
        var tokenBytes = RandomNumberGenerator.GetBytes(512);
        var refreshToken = Convert.ToBase64String(tokenBytes);

        return refreshToken;
    }
}
