using Classforce.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var application = builder.Build();

application.UseHttpsRedirection();

if (application.Environment.IsDevelopment())
{
    _ = application.UseSwagger();
    _ = application.UseSwaggerUI();
}

application.Run();
