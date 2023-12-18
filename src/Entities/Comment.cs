﻿using System.Diagnostics.CodeAnalysis;

namespace Classforce.Server.Entities;

public sealed class Comment
{
    public Comment() { }

    [SetsRequiredMembers]
    public Comment(Guid postId, Guid authorId, string content)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(content, nameof(content));

        PostId = postId;
        AuthorId = authorId;
        Content = content;
    }

    public Guid Id { get; init; }

    public required Guid PostId { get; init; }

    public Post Post { get; } = null!;

    public required Guid AuthorId { get; init; }

    public ApplicationUser Author { get; } = null!;

    public required string Content { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;
}
