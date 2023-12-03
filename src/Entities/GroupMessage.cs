using System.Diagnostics.CodeAnalysis;

namespace Classforce.Server.Entities;

public sealed class GroupMessage
{
    public GroupMessage() { }

    [SetsRequiredMembers]
    public GroupMessage(Guid groupId, Guid authorId, string content)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(content, nameof(content));

        GroupId = groupId;
        AuthorId = authorId;
        Content = content;
    }

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
