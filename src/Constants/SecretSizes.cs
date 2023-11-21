namespace Classforce.Server.Constants;

/// <summary>
/// Specifies the sizes of the secret codes, tokens, and keys used in the application.
/// </summary>
public static class SecretSizes
{
    /// <summary>
    /// The maximum value of the security code integer (exclusive).
    /// </summary>
    public const int MaxSecurityCode = 1000000;

    /// <summary>
    /// The number of random bytes in generated refresh tokens.
    /// </summary>
    public const int RefreshTokenBytes = 512;
}
