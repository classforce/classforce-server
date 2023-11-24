using System.ComponentModel.DataAnnotations;

namespace Classforce.Server.Models;

public sealed record SessionCreationRequest
{
    [Required]
    [EmailAddress]
    public required string Email { get; init; }

    [Required]
    [Range(0, 999999)]
    public required int Code { get; init; }
}
