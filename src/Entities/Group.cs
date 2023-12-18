using System.Diagnostics.CodeAnalysis;

namespace Classforce.Server.Entities;

public sealed class Group
{
    public Group() { }

    [SetsRequiredMembers]
    public Group(Guid organizationId, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        OrganizationId = organizationId;
        Name = name;
    }

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

    public ICollection<Post> Issues { get; } = null!;

    public ICollection<GroupMessage> Messages { get; } = null!;
}
