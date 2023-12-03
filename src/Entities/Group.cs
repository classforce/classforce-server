namespace Classforce.Server.Entities;

public sealed class Group
{
    public Guid Id { get; init; }

    public required Guid OrganizationId { get; init; }

    public Organization Organization { get; } = null!;

    public required string Name { get; set; }

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;

    public List<string> Tags { get; init; } = [];

    public ICollection<GroupMembership> Memberships { get; } = null!;

    public ICollection<Student> Students { get; } = null!;

    public ICollection<Schedule> Schedules { get; } = null!;

    public ICollection<Issue> Issues { get; } = null!;

    public ICollection<GroupMessage> Messages { get; } = null!;
}
