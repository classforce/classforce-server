using Classforce.Server.Services.Managers;

namespace Classforce.Server.Extensions;

/// <summary>
/// A class containing an extension method to register the <see cref="VerificationManager"/> service.
/// </summary>
public static class VerificationManagerExtension
{
    /// <summary>
    /// Registers the <see cref="VerificationManager"/> service in a <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>
    /// The same service collection so that multiple calls can be chained.
    /// </returns>
    ///  <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> are <see langword="null"/>.</exception>
    public static IServiceCollection AddVerificationManager(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        return services.AddScoped<VerificationManager>();
    }
}
