﻿using Classforce.Server.Enums;
using Microsoft.EntityFrameworkCore;

namespace Classforce.Server.Entities;

[PrimaryKey(nameof(UserId), nameof(OrganizationId))]
public sealed class OrganizationMembership
{
    public required Guid UserId { get; init; }

    public ApplicationUser User { get; } = null!;

    public required Guid OrganizationId { get; init; }

    public Organization Organization { get; } = null!;

    public OrganizationRole Role { get; set; }

    public DateTimeOffset FirstJoinTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastJoinTime { get; set; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastRoleChangeTime { get; set; } = DateTimeOffset.UtcNow;
}