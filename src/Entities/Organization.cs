using System.Diagnostics.CodeAnalysis;

namespace Classforce.Server.Entities;

public sealed class Organization
{
    public Organization() { }

    [SetsRequiredMembers]
    public Organization(string name, string? description = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        Name = name;
        Description = description;
    }

    public Guid Id { get; init; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;

    public ICollection<OrganizationMembership> Memberships { get; } = null!;

    public ICollection<Group> Groups { get; } = null!;
}
