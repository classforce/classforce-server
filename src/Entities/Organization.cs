namespace Classforce.Server.Entities;

public sealed class Organization
{
    public Guid Id { get; init; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;

    public ICollection<OrganizationMembership> Memberships { get; } = null!;

    public ICollection<Group> Groups { get; } = null!;
}
