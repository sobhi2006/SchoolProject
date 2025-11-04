using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Data.Configurations;

public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
{
    public void Configure(EntityTypeBuilder<StudentSubject> builder)
    {
        builder.ToTable("StudentSubjects");

        builder.HasOne<Student>(sb => sb.Student)
               .WithMany(s => s.StudentSubjects)
               .HasForeignKey(sb => sb.StudentId);

        builder.HasOne<Subject>(sb => sb.Subject)
               .WithMany(s => s.StudentSubjects)
               .HasForeignKey(sb => sb.SubjectId);
    }
}