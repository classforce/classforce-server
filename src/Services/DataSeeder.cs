using Classforce.Server.Constants;
using Classforce.Server.Entities;
using Microsoft.AspNetCore.Identity;

namespace Classforce.Server.Services;

/// <summary>
/// Service responsible for seeding the database with initial data.
/// </summary>
/// <param name="userManager">The user management service.</param>
/// <param name="roleManager">The role management service.</param>
public sealed class DataSeeder(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
{
    /// <summary>
    /// Creates default users and roles if they don't already exist.
    /// </summary>
    /// <returns>
    /// The <see cref="Task"/> that represents the asynchronous operation.
    /// </returns>
    public async Task SeedDataAsync()
    {
        await SeedRolesAsync();
        await SeedUsersAsync();
    }

    private async Task SeedRolesAsync()
    {
        await CreateRoleAsync(RoleNames.User);
        await CreateRoleAsync(RoleNames.Admin);
    }

    private async Task SeedUsersAsync()
    {
        await CreateUserAsync("user@classforce.net");
        await CreateUserAsync("admin@classforce.net", isAdmin: true);
    }

    private async Task CreateRoleAsync(string name)
    {
        if (!await roleManager.RoleExistsAsync(name))
        {
            var role = new ApplicationRole(name);
            var result = await roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create role '{name}': {result.Errors.FirstOrDefault()?.Description}");
            }
        }
    }

    private async Task CreateUserAsync(string email, bool isAdmin = false)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            user = new ApplicationUser(email)
            {
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create user '{email}': {result.Errors.FirstOrDefault()?.Description}");
            }
        }

        await AddUserToRoleAsync(user, RoleNames.User);

        if (isAdmin)
        {
            await AddUserToRoleAsync(user, RoleNames.Admin);
        }
        else
        {
            await RemoveUserFromRoleAsync(user, RoleNames.Admin);
        }
    }

    private async Task AddUserToRoleAsync(ApplicationUser user, string role)
    {
        if (!await userManager.IsInRoleAsync(user, role))
        {
            var result = await userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to add user '{user.Email}' to role '{role}': {result.Errors.FirstOrDefault()?.Description}");
            }
        }
    }

    private async Task RemoveUserFromRoleAsync(ApplicationUser user, string role)
    {
        if (await userManager.IsInRoleAsync(user, role))
        {
            var result = await userManager.RemoveFromRoleAsync(user, role);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to remove user '{user.Email}' from role '{role}': {result.Errors.FirstOrDefault()?.Description}");
            }
        }
    }
}
