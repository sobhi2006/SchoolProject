namespace SchoolProject.Core.Features.Subjects.Queries.Results;

public class GetSubjectResponse
{
    public GetSubjectResponse(Guid id, string subjectName, TimeSpan period)
    {
        Id = id;
        SubjectName = subjectName;
        Period = period;
    }

    public GetSubjectResponse()
    {
        
    }

    public Guid Id { get; set; }
    public string SubjectName { get; set; } = null!;
    public TimeSpan Period { get; set; }
}