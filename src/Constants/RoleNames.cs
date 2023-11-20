namespace Classforce.Server.Constants;

/// <summary>
/// Specifies the names of the roles used in the application.
/// </summary>
public static class RoleNames
{
    /// <summary>
    /// The default role for all authenticated users.
    /// </summary>
    public const string User = nameof(User);

    /// <summary>
    /// The highest available role with unrestricted access to all actions, resources, and settings.
    /// </summary>
    public const string Admin = nameof(Admin);
}
