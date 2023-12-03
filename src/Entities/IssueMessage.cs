namespace Classforce.Server.Entities;

public sealed class IssueMessage
{
    public Guid Id { get; init; }

    public required Guid IssueId { get; init; }

    public Issue Issue { get; } = null!;

    public required Guid AuthorId { get; init; }

    public ApplicationUser Author { get; } = null!;

    public required string Content { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;
}
