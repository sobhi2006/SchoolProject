using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Entities.Identity;
using SchoolProject.Infrastructure.Data.Configurations;

namespace SchoolProject.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<DepartmentSubject> DepartmentSubjects => Set<DepartmentSubject>();
    public DbSet<StudentSubject> StudentSubjects => Set<StudentSubject>();
    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<InstructorSubject> InstructorSubjects => Set<InstructorSubject>();
    public DbSet<UserRefreshToken> UserRefreshTokens => Set<UserRefreshToken>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);       // It is very important to set configuration of IdentityUser if, we remove it that will to crash error
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
    }
}