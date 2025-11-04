using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Data.Configurations;

public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubject>
{
    public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
    {
        builder.ToTable("DepartmentSubjects");

        builder.HasOne<Department>(ds => ds.Department)
               .WithMany(d => d.DepartmentSubjects)
               .HasForeignKey(ds => ds.DepartmentId);

        builder.HasOne<Subject>(ds => ds.Subject)
               .WithMany(s => s.DepartmentSubjects)
               .HasForeignKey(ds => ds.SubjectId);
    }
}