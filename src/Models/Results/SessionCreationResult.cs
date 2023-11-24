using System.Diagnostics.CodeAnalysis;

namespace Classforce.Server.Models.Results;

/// <summary>
/// Represents the result of a session creation, containing the refresh token.
/// </summary>
public sealed record SessionCreationResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SessionCreationResult"/> class.
    /// </summary>
    public SessionCreationResult() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SessionCreationResult"/> class with the specified <paramref name="refreshToken"/>.
    /// </summary>
    /// <param name="refreshToken">The refresh token associated with the session.</param>
    [SetsRequiredMembers]
    public SessionCreationResult(string refreshToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(refreshToken, nameof(refreshToken));
        RefreshToken = refreshToken;
    }

    /// <summary>
    /// Gets or sets the refresh token associated with the session, used to create access tokens.
    /// </summary>
    public required string RefreshToken { get; init; }
}
