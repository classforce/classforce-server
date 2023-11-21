using Classforce.Server.Services;

namespace Classforce.Server.Extensions;

/// <summary>
/// A class containing an extension method to register the <see cref="DataSeeder"/> service.
/// </summary>
public static class DataSeederExtension
{
    /// <summary>
    /// Registers the <see cref="DataSeeder"/> service in a <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>
    /// The same service collection so that multiple calls can be chained.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> are <see langword="null"/>.</exception>
    public static IServiceCollection AddDataSeeder(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        return services.AddScoped<DataSeeder>();
    }
}
