using System.Collections.Generic;
using System;
namespace SchoolProject.Domain.Entities;

public class Subject
{
    public Guid Id { get; set; }
    public string SubjectName { get; set; } = null!;
    public TimeSpan Period { get; set; }
    public virtual ICollection<StudentSubject> StudentSubjects { get; set; } = []; 
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = []; 
}