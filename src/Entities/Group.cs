namespace Classforce.Server.Entities;

public sealed class Group
{
    public Guid Id { get; init; }

    public required string Name { get; set; }

    public string Description { get; set; } = string.Empty;

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;

    public List<string> Tags { get; init; } = [];
}
