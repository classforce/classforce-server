using System.ComponentModel.DataAnnotations;

namespace Classforce.Server.Models.Requests;

public sealed record VerificationCreationRequest
{
    [Required]
    [EmailAddress]
    public required string Email { get; init; }
}
