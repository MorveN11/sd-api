using Moq;
using NUnit.Framework;
using Project.Business.Students.Delete;
using Project.Business.Students.Get;
using Project.Business.Students.Post;
using Project.Business.Students.Put;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Test.Handlers
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public async Task Should_Get_All_Careers_Of_A_Student()
        {
            var mockRepository = new Mock<IStudentRepository>();
            var testStudent = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                LastName = "Student",
                BirthDate = DateTime.Now
            };

            var testCareer = new Career { Id = Guid.NewGuid(), Name = "Test Career" };

            mockRepository
                .Setup(x => x.GetCareers(It.IsAny<Guid>()))
                .ReturnsAsync(new List<Career> { testCareer });

            var request = new GetStudentCareers(testStudent.Id);
            var handler = new GetStudentCareersHandler(mockRepository.Object);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<IEnumerable<Career>>());
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result.First(), Is.EqualTo(testCareer));

            mockRepository.Verify(x => x.GetCareers(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public async Task Should_Get_A_Student_By_Id()
        {
            var mockRepository = new Mock<IStudentRepository>();
            var testStudent = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                LastName = "Student",
                BirthDate = DateTime.Now
            };

            mockRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(testStudent);

            var request = new GetStudentById(testStudent.Id);
            var handler = new GetStudentByIdHandler(mockRepository.Object);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(testStudent));

            mockRepository.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public async Task Should_Delete_A_Student_By_Id()
        {
            var mockRepository = new Mock<IStudentRepository>();
            var testStudent = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                LastName = "Student",
                BirthDate = DateTime.Now
            };

            mockRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(testStudent);
            mockRepository.Setup(x => x.Delete(It.IsAny<Student>())).ReturnsAsync(1);

            var request = new DeleteStudentById(testStudent.Id);
            var handler = new DeleteStudentByIdHandler(mockRepository.Object);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.That(result, Is.EqualTo(1));

            mockRepository.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once);
            mockRepository.Verify(x => x.Delete(It.IsAny<Student>()), Times.Once);
        }

        [Test]
        public async Task Should_Create_A_Student()
        {
            var mockRepository = new Mock<IStudentRepository>();
            var testStudent = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                LastName = "Student",
                BirthDate = DateTime.Now
            };

            mockRepository.Setup(x => x.Create(It.IsAny<Student>())).ReturnsAsync(1);

            var request = new PostStudent(testStudent);
            var handler = new PostStudentHandler(mockRepository.Object);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.That(result, Is.EqualTo(1));

            mockRepository.Verify(x => x.Create(It.IsAny<Student>()), Times.Once);
        }

        [Test]
        public async Task Should_Update_A_Student()
        {
            var mockRepository = new Mock<IStudentRepository>();
            var testStudent = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                LastName = "Student",
                BirthDate = DateTime.Now
            };

            mockRepository.Setup(x => x.Update(It.IsAny<Student>())).ReturnsAsync(1);

            var request = new PutStudent(testStudent);
            var handler = new PutStudentHandler(mockRepository.Object);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.That(result, Is.EqualTo(1));

            mockRepository.Verify(x => x.Update(It.IsAny<Student>()), Times.Once);
        }
    }
}
