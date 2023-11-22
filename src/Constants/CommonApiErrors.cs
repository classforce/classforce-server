using Classforce.Server.Models;

namespace Classforce.Server.Constants;

public static class CommonApiErrors
{
    public static ApiError InvalidEmail => new(StatusCodes.Status400BadRequest, "INVALID_EMAIL", "The provided email address is invalid.");
}
