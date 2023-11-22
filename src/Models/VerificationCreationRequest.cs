using System.ComponentModel.DataAnnotations;

namespace Classforce.Server.Models;

public sealed record VerificationCreationRequest
{
    [Required]
    [EmailAddress]
    public required string Email { get; init; }
}
