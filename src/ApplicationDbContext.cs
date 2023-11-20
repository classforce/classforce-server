using Classforce.Server.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Classforce.Server;

/// <summary>
/// Represents the application database context.
/// </summary>
public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class with the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options to be used by the database context.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> are null.</exception>"
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        ArgumentNullException.ThrowIfNull(options, nameof(options));
    }
}
