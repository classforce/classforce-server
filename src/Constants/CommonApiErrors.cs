using Classforce.Server.Models;

namespace Classforce.Server.Constants;

public static class CommonApiErrors
{
    public static ApiError UnknownEmail => new(StatusCodes.Status401Unauthorized, "UNKNOWN_EMAIL", "There is no user associated with this email address.");

    public static ApiError InvalidEmail => new(StatusCodes.Status400BadRequest, "INVALID_EMAIL", "The provided email address is invalid.");

    public static ApiError InvalidVerificationCode => new(StatusCodes.Status401Unauthorized, "INVALID_VERIFICATION_CODE", "The provided verification code is invalid.");
}
