using AutoMapper;
using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Moq;
using SchoolProject.Core.Features.Students.Commands.Handler;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Mapping.Students;
using SchoolProject.Domain.Entities;
using SchoolProject.Service.Abstractions;
using System.Net;


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
        public async Task AddStudent_ShouldNotNullOrEmpty_ReturnStudent()
        {
            //Arrange
            var student = new AddStudentCommand();

            //Act
            _mockStudent.Setup(s => s.AddAsync(It.IsAny<Student>())).Returns(Task.FromResult(new Student { Id = Guid.NewGuid()})!);
            var handler = new StudentCommandHandler(_mockStudent.Object, _mapper);

            //Assert
            var result = await handler.Handle(student, default);
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateStudent_ShouldNotNullOrEmpty_ReturnStudent()
        {
            //Arrange
            var student = new UpdateStudentCommand()
            {
                Id = Guid.NewGuid()
            };

            //Act
            _mockStudent.Setup(s => s.GetStudentByIdAsync(student.Id)).Returns(Task.FromResult(new Student { Id = student.Id })!);
            _mockStudent.Setup(s => s.UpdateAsync(It.IsAny<Student>())).Returns(Task.FromResult(new Student { Id = student.Id })!);
            var handler = new StudentCommandHandler(_mockStudent.Object, _mapper);

            //Assert
            var result = await handler.Handle(student, default);
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task DeleteStudent_ShouldNotNullOrEmpty_ReturnStudent()
        {
            
            var DeleteStudent = new DeleteStudentCommand()
            {
                Id = Guid.NewGuid()
            };
            //Arrange
            var student = new Student()
            {
                Id = DeleteStudent.Id
            };

            //Act
            _mockStudent.Setup(s => s.GetStudentByIdAsync(student.Id)).Returns(Task.FromResult(student)!);
            _mockStudent.Setup(s => s.DeleteAsync(student)).Returns(Task.FromResult(new Student { Id = student.Id })!);
            var handler = new StudentCommandHandler(_mockStudent.Object, _mapper);

            //Assert
            var result = await handler.Handle(DeleteStudent, default);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
