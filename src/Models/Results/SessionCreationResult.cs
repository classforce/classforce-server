using System.Diagnostics.CodeAnalysis;

namespace Classforce.Server.Models.Results;

public sealed record SessionCreationResult
{
    public SessionCreationResult() { }

    [SetsRequiredMembers]
    public SessionCreationResult(string refreshToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(refreshToken, nameof(refreshToken));
        RefreshToken = refreshToken;
    }

    public required string RefreshToken { get; init; }
}
