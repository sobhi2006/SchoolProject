using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Data.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors");

        builder.Property(i => i.Salary)
               .HasColumnType("decimal(18,2)");

        builder.HasOne<Department>(i => i.Department)
               .WithMany(d => d.Instructors)
               .HasForeignKey(i => i.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Instructor>(i => i.Supervisor)
               .WithMany(i => i.Instructors)
               .HasForeignKey(i => i.SupervisorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}