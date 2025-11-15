using AutoMapper;
using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using SchoolProject.Core.Features.Queries.Handler;
using SchoolProject.Core.Features.Queries.Models;
using SchoolProject.Core.Mapping.Students;
using SchoolProject.Domain.Entities;
using SchoolProject.Domain.Helpers.Enums;
using SchoolProject.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.SchoolProject.Core.Tests.Students.Queries
{
    public class StudentQueryHandlerTest
    {
        private readonly Mock<IStudentService> _mockStudent = new();
        private readonly IMapper _mapper;
        private readonly StudentProfile _studentProfile = new();
        public StudentQueryHandlerTest()
        {
            var configuration = new MapperConfiguration(m => m.AddProfile(_studentProfile));
            _mapper = new Mapper(configuration);
        }
        [Fact]
        public async Task GetStudentsList_ShouldNotNullOrEmpty_ReturnListOfStudents()
        {
            //Arrange
            var students = new GetStudentQuery();
            var listStud = new List<Student>()
            {
                new()
                {
                    Id = Guid.NewGuid()
                }
            };
            _mockStudent.Setup(s => s.GetStudentsAsync()).Returns(Task.FromResult(listStud));
            var handler = new StudentQueryHandler(_mockStudent.Object, _mapper);

            //Assert
            var result = await handler.Handle(students, default);
            result.Data.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData("85bb3f6a-00c2-4c28-aca6-93564ca56a2c")]
        public async Task GetStudentById_ShouldNotNullOrEmpty_Student(Guid Id)
        {
            var listStud = new List<Student>()
            {
                new()
                {
                    Id = Guid.NewGuid()
                },
                new()
                {
                    Id = Id,
                    Name = "sop"
                }
            };
            var student = new GetStudentByIdQuery(Id);
            _mockStudent.Setup(s => s.GetStudentByIdAsync(Id)).Returns(Task.FromResult(listStud.FirstOrDefault(s => s.Id == Id)));
            var handler = new StudentQueryHandler(_mockStudent.Object, _mapper);

            //Assert
            var result = await handler.Handle(student, default);
            result.Data.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("85bb3f6a-00c2-4c28-aca6-93564ca56a3c")]
        public async Task GetStudentById_ShouldNullOrEmpty_Student(Guid Id)
        {
            var listStud = new List<Student>()
            {
                new()
                {
                    Id = Guid.NewGuid()
                }
            };
            var student = new GetStudentByIdQuery(Id);
            _mockStudent.Setup(s => s.GetStudentByIdAsync(Id)).Returns(Task.FromResult(listStud.FirstOrDefault(s => s.Id == Id)));
            var handler = new StudentQueryHandler(_mockStudent.Object, _mapper);

            //Assert
            var result = await handler.Handle(student, default);
            result.Data.Should().BeNull();
        }

        [Fact]
        public async Task GetStudentsPaginated_ShouldNotNullOrEmpty_ReturnListOfStudents()
        {
            //Arrange
            var students = new GetStudentPaginatedListQuery();
            var listStud = new AsyncEnumerable<Student>(new List<Student>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Department = new Department()
                    {
                        Id = Guid.NewGuid()
                    }
                }
            });

            _mockStudent.Setup(s => s.FilterStudentPaginatedQueryable(StudentOrdering.Id,null)).Returns(listStud.AsQueryable());
            var handler = new StudentQueryHandler(_mockStudent.Object, _mapper);

            //Assert
            var result = await handler.Handle(students, default);
            result.Data.Should().NotBeNullOrEmpty();
        }
    }
}
