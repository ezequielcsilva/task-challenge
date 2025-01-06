using TaskTracker.Application.Abstractions.Messaging;
using TaskTracker.Application.Tasks.GetTasks;
using TaskTracker.Domain.Abstractions;
using TaskTracker.Domain.Tasks;

namespace TaskTracker.Application.Tasks.GetAllTasks;

internal sealed class GetAllTasksQueryHandler(ITaskItemRepository taskItemRepository)
    : IQueryHandler<GetAllTasksQuery, Paginated<GetAllTasksResponse>>
{
    public async Task<Result<Paginated<GetAllTasksResponse>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks =
            await taskItemRepository.GetAllAsync(cancellationToken);

        var response = tasks
            .Select(r => new GetAllTasksResponse(
                r.Id,
                r.Name,
                r.Description,
                r.IsCompleted))
            .AsQueryable()
            .Page(request.Options.CurrentPage, request.Options.PageSize);

        return response;
    }
}