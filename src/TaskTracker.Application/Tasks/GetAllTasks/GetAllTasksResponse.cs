namespace TaskTracker.Application.Tasks.GetAllTasks;

public sealed record GetAllTasksResponse(
    Guid Id, 
    string Name, 
    string Description, 
    bool IsCompleted);