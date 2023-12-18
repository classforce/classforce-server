using Classforce.Server.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Classforce.Server;

/// <summary>
/// Represents the application database context.
/// </summary>
/// <param name="options">The options to be used by the database context.</param>
public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> of security sessions.
    /// </summary>
    public required DbSet<SecuritySession> SecuritySessions { get; init; }

    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> of email verifications.
    /// </summary>
    public required DbSet<EmailVerification> EmailVerifications { get; init; }

    public required DbSet<Organization> Organizations { get; init; }

    public required DbSet<OrganizationMembership> OrganizationMemberships { get; init; }

    public required DbSet<Group> Groups { get; init; }

    public required DbSet<GroupMembership> GroupMemberships { get; init; }

    public required DbSet<Student> Students { get; init; }

    public required DbSet<Schedule> Schedules { get; init; }

    public required DbSet<Unschedule> Unschedules { get; init; }

    public required DbSet<Post> Posts { get; init; }

    public required DbSet<GroupMessage> GroupMessages { get; init; }

    public required DbSet<Comment> Comments { get; init; }

    public required DbSet<DirectMessage> DirectMessages { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.SecuritySessions).WithOne(s => s.User).HasForeignKey(s => s.UserId);
        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.EmailVerifications).WithOne(e => e.User).HasForeignKey(e => e.UserId);
        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.OrganizationMemberships).WithOne(m => m.User).HasForeignKey(m => m.UserId);
        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.GroupMemberships).WithOne(m => m.User).HasForeignKey(m => m.UserId);
        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.CreatedIssues).WithOne(i => i.Author).HasForeignKey(i => i.AuthorId);
        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.SentDirectMessages).WithOne(m => m.Author).HasForeignKey(m => m.AuthorId);
        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.ReceivedDirectMessages).WithOne(m => m.Recipient).HasForeignKey(m => m.RecipientId);
        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.SentGroupMessages).WithOne(m => m.Author).HasForeignKey(m => m.AuthorId);
        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.SentIssueMessages).WithOne(m => m.Author).HasForeignKey(m => m.AuthorId);

        _ = modelBuilder.Entity<Organization>().HasMany(o => o.Memberships).WithOne(m => m.Organization).HasForeignKey(m => m.OrganizationId);
        _ = modelBuilder.Entity<Organization>().HasMany(o => o.Groups).WithOne(g => g.Organization).HasForeignKey(g => g.OrganizationId);

        _ = modelBuilder.Entity<Group>().HasMany(g => g.Memberships).WithOne(m => m.Group).HasForeignKey(m => m.GroupId);
        _ = modelBuilder.Entity<Group>().HasMany(g => g.Students).WithOne(s => s.Group).HasForeignKey(s => s.GroupId);
        _ = modelBuilder.Entity<Group>().HasMany(g => g.Schedules).WithOne(s => s.Group).HasForeignKey(s => s.GroupId);
        _ = modelBuilder.Entity<Group>().HasMany(g => g.Posts).WithOne(i => i.Group).HasForeignKey(i => i.GroupId);
        _ = modelBuilder.Entity<Group>().HasMany(g => g.Messages).WithOne(m => m.Group).HasForeignKey(m => m.GroupId);

        _ = modelBuilder.Entity<Schedule>().HasMany(s => s.Unschedules).WithOne(u => u.Schedule).HasForeignKey(u => u.ScheduleId);
        _ = modelBuilder.Entity<Post>().HasMany(i => i.Messages).WithOne(m => m.Issue).HasForeignKey(m => m.IssueId);
    }
}
