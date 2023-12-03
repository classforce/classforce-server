namespace Classforce.Server.Entities;

public sealed class GroupMessage
{
    public Guid Id { get; init; }

    public required Guid GroupId { get; init; }

    public Group Group { get; } = null!;

    public required Guid AuthorId { get; init; }

    public ApplicationUser Author { get; } = null!;

    public required string Content { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;
}
