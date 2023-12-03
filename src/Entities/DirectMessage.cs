namespace Classforce.Server.Entities;

public class DirectMessage
{
    public Guid Id { get; init; }

    public required Guid AuthorId { get; init; }

    public ApplicationUser Author { get; } = null!;

    public required Guid RecipientId { get; init; }

    public ApplicationUser Recipient { get; } = null!;

    public required string Content { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;
}
