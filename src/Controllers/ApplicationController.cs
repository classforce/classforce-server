using Classforce.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Classforce.Server.Controllers;

/// <summary>
/// The base class for all Classforce API controllers.
/// </summary>
public class ApplicationController : ControllerBase
{
    /// <summary>
    /// Creates a request result with the specified <paramref name="apiError"/>.
    /// </summary>
    /// <param name="apiError">The error that occurred while processing the request.</param>
    /// <returns>
    /// The created request result containing the API error.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="apiError"/> is <see langword="null"/>.</exception>
    [NonAction]
    public ObjectResult ApiError(ApiError apiError)
    {
        ArgumentNullException.ThrowIfNull(apiError, nameof(apiError));

        var result = new ObjectResult(apiError)
        {
            StatusCode = apiError.StatusCode
        };

        return result;
    }
}
