using System.Diagnostics.CodeAnalysis;

namespace Classforce.Server.Entities;

/// <summary>
/// Represents a community of students in an organization.
/// </summary>
public sealed class Group
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Group"/> class.
    /// </summary>
    public Group() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Group"/> class with the specified parent organization identifier and name.
    /// </summary>
    /// <param name="organizationId">The identifier of the parent organization that the group is located in.</param>
    /// <param name="name">The name of the group.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="name"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="name"/> consists only of white-space characters.</exception>
    [SetsRequiredMembers]
    public Group(Guid organizationId, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        OrganizationId = organizationId;
        Name = name;
    }

    /// <summary>
    /// Gets or sets the unique identifier of the group.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets or sets the unique identifier of the parent organization that the group is located in.
    /// </summary>
    public required Guid OrganizationId { get; init; }

    /// <summary>
    /// Gets the parent organization that the group is located in.
    /// </summary>
    public Organization Organization { get; } = null!;

    /// <summary>
    /// Gets or sets the name of the group.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the group.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets a flag indicating whether the group has been soft deleted.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the group has been soft deleted, otherwise, <see langword="false"/>.
    /// </value>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the group was created.
    /// </summary>
    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets or sets the date and time when the group details (e.g. name) were last updated.
    /// </summary>
    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;

    /// <summary>
    /// Gets or sets the list of tags associated with the group.
    /// </summary>
    public List<string> Tags { get; init; } = [];

    /// <summary>
    /// Gets the collection of all memberships of application users in this group.
    /// </summary>
    public ICollection<GroupMembership> Memberships { get; } = null!;

    /// <summary>
    /// Gets the collection of all students that are members of this group.
    /// </summary>
    public ICollection<Student> Students { get; } = null!;

    /// <summary>
    /// Gets the collection of all events planned for this group (e.g. courses, exams, meetings).
    /// </summary>
    public ICollection<Schedule> Schedules { get; } = null!;

    /// <summary>
    /// Gets the collection of all posts created in this group.
    /// </summary>
    public ICollection<Post> Posts { get; } = null!;

    /// <summary>
    /// Gets the collection of all messages sent in the group chat.
    /// </summary>
    public ICollection<GroupMessage> Messages { get; } = null!;
}
