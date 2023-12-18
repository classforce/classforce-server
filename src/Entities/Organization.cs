using System.Diagnostics.CodeAnalysis;

namespace Classforce.Server.Entities;

/// <summary>
/// Represents a university, school, or other type of organization that consists of groups.
/// </summary>
public sealed class Organization
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Organization"/> class.
    /// </summary>
    public Organization() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Organization"/> class with the specified name and optional description.
    /// </summary>
    /// <param name="name">The name of the organization.</param>
    /// <param name="description">The optional description of the organization.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="description"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="description"/> consists only of white-space characters.</exception>
    [SetsRequiredMembers]
    public Organization(string name, string? description = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        Name = name;
        Description = description;
    }

    /// <summary>
    /// Gets or sets the unique identifier of the organization.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets the name of the organization.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the organization.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets a flag indicating whether the organization has been soft deleted.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the organization has been soft deleted, otherwise, <see langword="false"/>.
    /// </value>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the organization was created.
    /// </summary>
    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets or sets the date and time when the organization details (e.g. name, description) were last updated.
    /// </summary>
    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets the collection of all memberships of application users in this organization.
    /// </summary>
    public ICollection<OrganizationMembership> Memberships { get; } = null!;

    /// <summary>
    /// Gets the collection of all groups in this organization.
    /// </summary>
    public ICollection<Group> Groups { get; } = null!;
}
