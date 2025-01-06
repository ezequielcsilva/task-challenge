using TaskTracker.Application.Abstractions.Messaging;
using TaskTracker.Domain.Abstractions;

namespace TaskTracker.Application.Tasks.CreateTask;

internal class CreateTaskCommandHandler : ICommandHandler<CreateTaskCommand, CreateTaskResult>
{
    public Task<Result<CreateTaskResult>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}