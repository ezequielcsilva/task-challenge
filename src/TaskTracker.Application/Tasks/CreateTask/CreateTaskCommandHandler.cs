using TaskTracker.Application.Abstractions.Data;
using TaskTracker.Application.Abstractions.Messaging;
using TaskTracker.Domain.Abstractions;
using TaskTracker.Domain.Tasks;

namespace TaskTracker.Application.Tasks.CreateTask;

internal sealed class CreateTaskCommandHandler(ITaskItemRepository taskItemRepository, IDbContext dbContext) : ICommandHandler<CreateTaskCommand, CreateTaskResult>
{
    public async Task<Result<CreateTaskResult>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskItem = TaskItem.Create(request.Request.Name, request.Request.Description, request.Request.IsCompleted);

        taskItemRepository.Add(taskItem);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateTaskResult(taskItem.Id);
    }
}