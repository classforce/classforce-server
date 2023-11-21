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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.SecuritySessions).WithOne(s => s.User).HasForeignKey(s => s.UserId);
        _ = modelBuilder.Entity<ApplicationUser>().HasMany(u => u.EmailVerifications).WithOne(e => e.User).HasForeignKey(e => e.UserId);
    }
}
