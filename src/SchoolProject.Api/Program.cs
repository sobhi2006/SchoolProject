using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.Core;
using SchoolProject.Core.Middleware;
using SchoolProject.Infrastructure;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnection"]);
});
builder.Services.AddControllers();
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

app.Run();
