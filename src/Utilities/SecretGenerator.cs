using System.Security.Cryptography;
using Classforce.Server.Constants;

namespace Classforce.Server.Utilities;

/// <summary>
/// A utility class for generating secret codes, tokens, and keys.
/// </summary>
public static class SecretGenerator
{
    /// <summary>
    /// Generates a new random security code for the purpose of identity verification.
    /// </summary>
    /// <returns>
    /// The generated security code.
    /// </returns>
    public static int CreateSecurityCode()
    {
        var securityCode = RandomNumberGenerator.GetInt32(SecretSizes.MaxSecurityCode);
        return securityCode;
    }

    /// <summary>
    /// Generates a new random refresh token for the purpose of securing user sessions.
    /// </summary>
    /// <returns>
    /// The generated refresh token.
    /// </returns>
    public static string CreateRefreshToken()
    {
        var tokenBytes = RandomNumberGenerator.GetBytes(SecretSizes.RefreshTokenBytes);
        var refreshToken = Convert.ToBase64String(tokenBytes);

        return refreshToken;
    }
}
