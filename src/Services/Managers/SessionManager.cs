using Classforce.Server.Entities;

namespace Classforce.Server.Services.Managers;

/// <summary>
/// Service responsible for the management of security sessions.
/// </summary>
/// <param name="context">The application database context.</param>
public sealed class SessionManager(ApplicationDbContext context)
{
    /// <summary>
    /// Gets the queryable source of all security sessions.
    /// </summary>
    public IQueryable<SecuritySession> Sessions => context.SecuritySessions;

    /// <summary>
    /// Creates a new security <paramref name="session"/> and adds it to the database.
    /// </summary>
    /// <param name="session">The security session to create.</param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> is <see langword="null"/>.</exception>
    public async Task CreateAsync(SecuritySession session)
    {
        ArgumentNullException.ThrowIfNull(session, nameof(session));

        _ = await context.SecuritySessions.AddAsync(session);
        _ = await context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves a security session by its unique identifier (primary key).
    /// </summary>
    /// <param name="sessionId">The unique identifier of the security session.</param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation,
    /// containg the found <see cref="SecuritySession"/> or <see langword="null"/> if no match.
    /// </returns>
    public async Task<SecuritySession?> FindByIdAsync(Guid sessionId)
    {
        return await context.SecuritySessions.FindAsync(sessionId);
    }

    /// <summary>
    /// Saves changes made to the specified security <paramref name="session"/> to the database.
    /// </summary>
    /// <param name="session">The modified security session to update.</param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> is <see langword="null"/>.</exception>
    public async Task UpdateAsync(SecuritySession session)
    {
        ArgumentNullException.ThrowIfNull(session, nameof(session));

        _ = context.SecuritySessions.Update(session);
        _ = await context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes the specified security <paramref name="session"/> from the database.
    /// </summary>
    /// <param name="session">The security session to delete.</param>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="session"/> is <see langword="null"/>.</exception>
    public async Task DeleteAsync(SecuritySession session)
    {
        ArgumentNullException.ThrowIfNull(session, nameof(session));

        _ = context.SecuritySessions.Remove(session);
        _ = await context.SaveChangesAsync();
    }
}
