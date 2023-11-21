using Classforce.Server;
using Classforce.Server.Constants;
using Classforce.Server.Entities;
using Classforce.Server.Extensions;
using Classforce.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite(connectionString));
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(o => o.User.RequireUniqueEmail = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddJwtBearerAuthentication(builder.Configuration);
builder.Services.AddAuthorizationBuilder()
    .AddPolicy(PolicyNames.Users, policy => policy.RequireRole(RoleNames.User))
    .AddPolicy(PolicyNames.Admins, policy => policy.RequireRole(RoleNames.Admin));

builder.Services.AddDataSeeder();
builder.Services.AddAmazonSES();
builder.Services.AddVerificationManager();
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var application = builder.Build();

application.UseHttpsRedirection();
application.UseAuthentication();
application.UseAuthorization();
application.MapHealthChecks("/health");

if (application.Environment.IsDevelopment())
{
    _ = application.UseSwagger();
    _ = application.UseSwaggerUI();
}

await using var dataSeederScope = application.Services.CreateAsyncScope();
await dataSeederScope.ServiceProvider.GetRequiredService<DataSeeder>().SeedDataAsync();

application.Run();
