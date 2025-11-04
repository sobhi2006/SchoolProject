using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.Property(s => s.Address)
               .HasColumnType("NVARCHAR(500)");

        builder.HasIndex(s => s.Name);

        builder.HasOne<Department>(s => s.Department)
               .WithMany(d => d.Students)
               .HasForeignKey(s => s.DepartmentId);
    }
}