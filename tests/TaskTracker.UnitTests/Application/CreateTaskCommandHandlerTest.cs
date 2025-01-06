using Bogus;
using FluentAssertions;
using NSubstitute;
using TaskTracker.Application.Abstractions.Data;
using TaskTracker.Application.Tasks.CreateTask;
using TaskTracker.Domain.Tasks;

namespace TaskTracker.UnitTests.Application;

public class CreateTaskCommandHandlerTest
{
    [Fact]
    public async Task Handle_ShouldCreateTaskItemCorrectly_WhenRequestIsValid()
    {
        // Arrange
        var faker = new Faker();
        var request = new CreateTaskCommand(new CreateTaskRequest(
            faker.Lorem.Word(),
            faker.Lorem.Sentence(),
            faker.Random.Bool()
        ));

        var mockTaskItemRepository = Substitute.For<ITaskItemRepository>();
        var mockDbContext = Substitute.For<IDbContext>();

        var handler = new CreateTaskCommandHandler(mockTaskItemRepository, mockDbContext);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();

        await mockDbContext.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
        mockTaskItemRepository.Received(1).Add(Arg.Is<TaskItem>(t =>
            t.Name == request.Request.Name &&
            t.Description == request.Request.Description &&
            t.IsCompleted == request.Request.IsCompleted));
    }
}