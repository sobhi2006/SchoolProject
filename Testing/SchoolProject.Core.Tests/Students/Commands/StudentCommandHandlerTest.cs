using AutoMapper;
using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Moq;
using SchoolProject.Core.Features.Queries.Handler;
using SchoolProject.Core.Features.Queries.Models;
using SchoolProject.Core.Features.Students.Commands.Handler;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Mapping.Students;
using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.SchoolProject.Core.Tests.Students.Commands
{
    public class StudentCommandHandlerTest
    {
        private readonly Mock<IStudentService> _mockStudent = new();
        private readonly IMapper _mapper;
        private readonly StudentProfile _studentProfile = new();
        public StudentCommandHandlerTest()
        {
            var configuration = new MapperConfiguration(m => m.AddProfile(_studentProfile));
            _mapper = new Mapper(configuration);
        }

        [Fact]
        public async Task GetStudentsPaginated_ShouldNotNullOrEmpty_ReturnListOfStudents()
        {
            //Arrange
            var student = new AddStudentCommand();

            _mockStudent.Setup(s => s.AddAsync(It.IsAny<Student>())).Returns(Task.FromResult(new Student { Id = Guid.NewGuid()})!);
            var handler = new StudentCommandHandler(_mockStudent.Object, _mapper);

            //Assert
            var result = await handler.Handle(student, default);
            result.Data.Should().NotBeNull();
        }
    }
}
