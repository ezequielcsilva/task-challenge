using Bogus;
using FluentAssertions;
using NSubstitute;
using TaskTracker.Application.Abstractions.Messaging;
using TaskTracker.Application.Tasks.GetAllTasks;
using TaskTracker.Application.Tasks.GetTasks;
using TaskTracker.Domain.Tasks;

namespace TaskTracker.UnitTests.Application;

public class GetAllTasksQueryHandlerTest
{
    [Fact]
    public async Task Handle_ShouldReturnPaginatedTasks_WhenTasksExist()
    {
        // Arrange
        var faker = new Faker();
        var tasks = new List<TaskItem>
        {
            TaskItem.Create(faker.Lorem.Word(), faker.Lorem.Sentence(), faker.Random.Bool()),
            TaskItem.Create(faker.Lorem.Word(), faker.Lorem.Sentence(), faker.Random.Bool()),
            TaskItem.Create(faker.Lorem.Word(), faker.Lorem.Sentence(), faker.Random.Bool())
        };

        var options = new PaginatedOptions()
        {
            CurrentPage = 1,
            PageSize = 2
        };

        var request = new GetAllTasksQuery(options);

        var mockTaskItemRepository = Substitute.For<ITaskItemRepository>();
        mockTaskItemRepository.GetAllAsync(Arg.Any<CancellationToken>()).Returns(tasks);

        var handler = new GetAllTasksQueryHandler(mockTaskItemRepository);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Data.Should().HaveCount(2);
        result.Value.Data.Should().BeEquivalentTo(tasks
            .Take(2)
            .Select(t => new GetAllTasksResponse(t.Id, t.Name, t.Description, t.IsCompleted)));

        mockTaskItemRepository.Received(1).GetAllAsync(Arg.Any<CancellationToken>());
    }
}