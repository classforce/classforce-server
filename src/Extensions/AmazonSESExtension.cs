using Classforce.Server.Services;

namespace Classforce.Server.Extensions;

/// <summary>
/// A class containing an extension method to register the <see cref="AmazonSES"/> service.
/// </summary>
public static class AmazonSESExtension
{
    /// <summary>
    /// Registers the <see cref="AmazonSES"/> service in a <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>
    /// The same service collection so that multiple calls can be chained.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> are <see langword="null"/>.</exception>
    public static IServiceCollection AddAmazonSES(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        return services.AddScoped<IEmailService, AmazonSES>();
    }
}
