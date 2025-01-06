using TaskTracker.Application.Abstractions.Messaging;
using TaskTracker.Application.Tasks.GetAllTasks;

namespace TaskTracker.Application.Tasks.GetTasks;

public sealed record GetAllTasksQuery(PaginatedOptions Options)
    : IQuery<Paginated<GetAllTasksResponse>>;