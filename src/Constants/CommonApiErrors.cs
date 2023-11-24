using Classforce.Server.Models;

namespace Classforce.Server.Constants;

/// <summary>
/// Provides a set of common <see cref="ApiError"/>s returned by API controllers.
/// </summary>
public static class CommonApiErrors
{
    /// <summary>
    /// Gets the <see cref="ApiError"/> returned when a user attempts to create a session with an email address that is not associated with any user.
    /// </summary>
    public static ApiError UnknownEmail => new(StatusCodes.Status401Unauthorized, "UNKNOWN_EMAIL", "There is no user associated with this email address.");

    /// <summary>
    /// Gets the <see cref="ApiError"/> returned when a user provides a string that is not a valid email address.
    /// </summary>
    public static ApiError InvalidEmail => new(StatusCodes.Status400BadRequest, "INVALID_EMAIL", "The provided email address is invalid.");

    /// <summary>
    /// Gets the <see cref="ApiError"/> returned when a user provides a verification code that is malformed, incorrect, has already been used, or has expired.
    /// </summary>
    public static ApiError InvalidVerificationCode => new(StatusCodes.Status401Unauthorized, "INVALID_VERIFICATION_CODE", "The provided verification code is invalid.");
}
