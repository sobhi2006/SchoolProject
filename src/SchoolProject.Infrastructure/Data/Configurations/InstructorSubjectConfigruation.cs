using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Infrastructure.Data.Configurations;

public class InstructorSubjectConfiguration : IEntityTypeConfiguration<InstructorSubject>
{
    public void Configure(EntityTypeBuilder<InstructorSubject> builder)
    {
        builder.ToTable("InstructorSubjects");

        builder.HasOne<Instructor>(Is => Is.Instructor)
               .WithMany(i => i.InstructorSubjects)
               .HasForeignKey(Is => Is.InstructorId);

        builder.HasOne<Subject>(Is => Is.Subject)
               .WithMany(s => s.InstructorSubjects)
               .HasForeignKey(Is => Is.SubjectId);
    }
}