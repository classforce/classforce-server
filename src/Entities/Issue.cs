using System.Diagnostics.CodeAnalysis;
using Classforce.Server.Enums;

namespace Classforce.Server.Entities;

public sealed class Issue
{
    public Issue() { }

    [SetsRequiredMembers]
    public Issue(Guid groupId, Guid authorId, IssueType type, string? name = null)
    {
        GroupId = groupId;
        AuthorId = authorId;
        Type = type;
        Name = name;
    }

    public Guid Id { get; init; }

    public required Guid GroupId { get; init; }

    public Group Group { get; } = null!;

    public required Guid AuthorId { get; init; }

    public ApplicationUser Author { get; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public IssueType Type { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset? DueTime { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;

    public List<string> Tags { get; init; } = [];

    public ICollection<IssueMessage> Messages { get; } = null!;
}
