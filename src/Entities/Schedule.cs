﻿using Classforce.Server.Enums;

namespace Classforce.Server.Entities;

public sealed class Schedule
{
    public Guid Id { get; init; }

    public string? Name { get; set; }

    public string Description { get; set; } = string.Empty;

    public string? Location { get; set; }

    public string? Supervisor { get; set; }

    public bool IsDeleted { get; set; }

    public Frequency Frequency { get; set; }

    public required DateTimeOffset StartTime { get; set; }

    public required DateTimeOffset EndTime { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;

    public List<string> Tags { get; init; } = [];
}