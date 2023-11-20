namespace Classforce.Server.Constants;

/// <summary>
/// Specifies the names of the authorization policies used in the application.
/// </summary>
public static class PolicyNames
{
    /// <summary>
    /// A policy that requires the user to be authenticated.
    /// </summary>
    public const string Users = nameof(Users);

    /// <summary>
    /// A policy that requires the user to be an administrator.
    /// </summary>
    public const string Admins = nameof(Admins);
}
