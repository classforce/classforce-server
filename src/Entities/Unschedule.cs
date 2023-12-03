﻿namespace Classforce.Server.Entities;

public sealed class Unschedule
{
    public Guid Id { get; init; }

    public required Guid ScheduleId { get; init; }

    public Schedule Schedule { get; } = null!;

    public bool IsDeleted { get; set; }

    public required DateTimeOffset StartTime { get; set; }

    public required DateTimeOffset EndTime { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;
}
