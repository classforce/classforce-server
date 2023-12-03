using Classforce.Server.Enums;

namespace Classforce.Server.Entities;

public sealed class Issue
{
    public Guid Id { get; init; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public IssueType Type { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset? DueTime { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;

    public List<string> Tags { get; init; } = [];
}
