namespace Classforce.Server.Entities;

public sealed class Student
{
    public Guid Id { get; init; }

    public required Guid GroupId { get; init; }

    public Group Group { get; } = null!;

    public required string FistNames { get; set; }

    public string? LastName { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;
}
