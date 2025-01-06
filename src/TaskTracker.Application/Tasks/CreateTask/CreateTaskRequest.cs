namespace TaskTracker.Application.Tasks.CreateTask;

public record CreateTaskRequest(string Name, string Description, bool IsCompleted);