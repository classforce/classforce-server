using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Classforce.Server.Extensions;

/// <summary>
/// A class containing an extension method to register the JWT Bearer authentication service.
/// </summary>
public static class AuthenticationExtension
{
    /// <summary>
    /// Registers the JWT Bearer authentication service in a <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The application settings.</param>
    /// <returns>
    /// The same service collection so that multiple calls can be chained.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> or <paramref name="configuration"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">Thrown when JWT Bearer authentication settings are not configured.</exception>
    public static IServiceCollection AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentNullException.ThrowIfNull(configuration, nameof(configuration));

        _ = services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var issuer = configuration["Authentication:JwtBearer:Issuer"];
            if (string.IsNullOrWhiteSpace(issuer))
            {
                throw new InvalidOperationException("The JWT Bearer issuer is null or white space.");
            }

            var audience = configuration["Authentication:JwtBearer:Audience"];
            if (string.IsNullOrWhiteSpace(audience))
            {
                throw new InvalidOperationException("The JWT Bearer audience is null or white space.");
            }

            o.TokenValidationParameters.ValidIssuer = issuer;
            o.TokenValidationParameters.ValidAudience = audience;
            o.TokenValidationParameters.IssuerSigningKey = GetIssuerSigningKey(configuration);
        });

        return services;
    }

    private static SymmetricSecurityKey GetIssuerSigningKey(IConfiguration configuration)
    {
        var keyString = configuration["Authentication:JwtBearer:SigningKey"];
        if (string.IsNullOrWhiteSpace(keyString))
        {
            throw new InvalidOperationException("The JWT Bearer signing key is null or white space.");
        }

        var keyBytes = Encoding.Default.GetBytes(keyString);
        var signingKey = new SymmetricSecurityKey(keyBytes);

        return signingKey;
    }
}
