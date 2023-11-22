using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Classforce.Server.Utilities;

/// <summary>
/// Utility class containing a method to configure Swagger to support JWT Bearer Authentication scheme.
/// </summary>
public static class SwaggerOptions
{
    /// <summary>
    /// Configures Swagger to support the JWT Bearer Authentication scheme.
    /// </summary>
    /// <param name="options">The Swagger options.</param>
    public static void SetupJwtBearer(SwaggerGenOptions options)
    {
        var reference = new OpenApiReference
        {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme
        };

        var scheme = new OpenApiSecurityScheme
        {
            Scheme = "Bearer",
            Name = "Bearer",
            Description = "JWT Bearer Authentication",
            BearerFormat = "JWT",
            Type = SecuritySchemeType.ApiKey,
            In = ParameterLocation.Header,
            Reference = reference
        };

        options.AddSecurityDefinition("Bearer", scheme);

        var requirement = new OpenApiSecurityRequirement
        {
            { new OpenApiSecurityScheme{ Reference = reference }, Array.Empty<string>() }
        };

        options.AddSecurityRequirement(requirement);
    }
}
