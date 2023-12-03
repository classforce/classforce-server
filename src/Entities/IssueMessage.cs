using System.Diagnostics.CodeAnalysis;

namespace Classforce.Server.Entities;

public sealed class IssueMessage
{
    public IssueMessage() { }

    [SetsRequiredMembers]
    public IssueMessage(Guid issueId, Guid authorId, string content)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(content, nameof(content));

        IssueId = issueId;
        AuthorId = authorId;
        Content = content;
    }

    public Guid Id { get; init; }

    public required Guid IssueId { get; init; }

    public Issue Issue { get; } = null!;

    public required Guid AuthorId { get; init; }

    public ApplicationUser Author { get; } = null!;

    public required string Content { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset CreationTime { get; init; } = DateTimeOffset.UtcNow;

    public DateTimeOffset LastEditTime { get; set; } = DateTimeOffset.UtcNow;
}
