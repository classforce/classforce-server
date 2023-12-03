namespace Classforce.Server.Entities;

public sealed class IssueMessage
{
    public Guid Id { get; init; }

    public required string Content { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;
}
