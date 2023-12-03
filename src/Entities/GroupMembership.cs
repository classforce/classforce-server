using Classforce.Server.Enums;
using Microsoft.EntityFrameworkCore;

namespace Classforce.Server.Entities;

[PrimaryKey(nameof(GroupId), nameof(UserId))]
public sealed class GroupMembership
{
    public required Guid UserId { get; init; }

    public ApplicationUser User { get; } = null!;

    public required Guid GroupId { get; init; }

    public Group Group { get; } = null!;

    public required Guid UserId { get; init; }

    public ApplicationUser User { get; } = null!;

    public OrganizationRole Role { get; set; }

    public DateTimeOffset FirstJoinTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastJoinTime { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastRoleChangeTime { get; set; } = DateTimeOffset.UtcNow;
}
