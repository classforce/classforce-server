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
    /// Initialized a new instance of the <see cref="ApiError"/> class with the specified <paramref name="title"/> and optional <paramref name="message"/>.
    /// </summary>
    /// <param name="title">The title of the error.</param>
    /// <param name="message">The human-readable description of the error.</param>
    public ApiError(string title, string? message = null)
    {
        Title = title;
        Message = message;
    }

    /// <summary>
    /// Gets or sets the title of the error.
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// Gets or sets the human-readable description of the error.
    /// </summary>
    public string? Message { get; init; }
}
