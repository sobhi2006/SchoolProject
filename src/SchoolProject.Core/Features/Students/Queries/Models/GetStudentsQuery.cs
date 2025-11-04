using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Queries.Results;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Core.Features.Queries.Models;


public class GetStudentQuery : IRequest<Response<List<GetStudentResponse>>>
{
    
}