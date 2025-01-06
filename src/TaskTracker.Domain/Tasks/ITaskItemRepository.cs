namespace TaskTracker.Domain.Tasks;

public interface ITaskItemRepository
{
    Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default);

    void Add(TaskItem taskItem);
}