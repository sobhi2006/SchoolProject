using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.Core;
using SchoolProject.Core.Filters;
using SchoolProject.Core.Middleware;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Infrastructure;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.DataSeeding;
using SchoolProject.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnection"]);
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<AuthFilter>();
});
builder.Services.AddInfrastructureDependency();
builder.Services.AddServiceDependency();
builder.Services.AddCoreDependency();
builder.Services.AddServiceRegistrations(builder.Configuration);


builder.Services.AddCors(options =>
{
    options.AddPolicy("Any", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseCors("Any");
app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.UseMiddleware<ErrorHandlerMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

    await RoleSeed.SeedAsync(roleManager!);    
    await UserSeed.SeedAsync(userManager!);    
}

app.Run();
