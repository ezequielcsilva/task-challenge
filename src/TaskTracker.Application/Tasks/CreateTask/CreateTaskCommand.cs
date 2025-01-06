using TaskTracker.Application.Abstractions.Messaging;

namespace TaskTracker.Application.Tasks.CreateTask;

public record CreateTaskCommand(CreateTaskRequest Request) : ICommand<CreateTaskResult>;