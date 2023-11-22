namespace Classforce.Server.Models;

/// <summary>
/// Represents an error returned by an API controller.
/// </summary>
public sealed record ApiError
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiError"/> class.
    /// </summary>
    public ApiError() { }

    /// <summary>
    /// Initialized a new instance of the <see cref="ApiError"/> class with the specified HTTP <paramref name="statusCode"/>, <paramref name="title"/> and optional <paramref name="message"/>.
    /// </summary>
    /// <param name="statusCode">The HTTP status code associated with the error.</param>
    /// <param name="title">The title of the error.</param>
    /// <param name="message">The human-readable description of the error.</param>
    public ApiError(int statusCode, string title, string? message = null)
    {
        StatusCode = statusCode;
        Title = title;
        Message = message;
    }

    /// <summary>
    /// Gets or sets the HTTP status code associated with the error.
    /// </summary>
    public required int StatusCode { get; init; }

    /// <summary>
    /// Gets or sets the title of the error.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Gets or sets the human-readable description of the error.
    /// </summary>
    public string? Message { get; init; }
}
