using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain.Tasks;

namespace TaskTracker.Infrastructure.Repositories;

internal sealed class TaskItemRepository(ApplicationDbContext dbContext)
    : Repository<TaskItem>(dbContext), ITaskItemRepository
{
    public async Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext
             .Tasks
             .AsNoTracking()
             .ToArrayAsync(cancellationToken);
    }
}