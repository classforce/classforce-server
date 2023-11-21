using Classforce.Server.Services.Managers;

namespace Classforce.Server.Extensions;

/// <summary>
/// A class containing an extension method to register all manager services.
/// </summary>
public static class ManagersExtension
{
    /// <summary>
    /// Registers all manager services in a <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>
    /// The same service collection so that multiple calls can be chained.
    /// </returns>
    ///  <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> are <see langword="null"/>.</exception>
    public static IServiceCollection AddManagers(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        _ = services.AddScoped<SessionManager>();
        _ = services.AddScoped<VerificationManager>();

        return services;
    }
}
