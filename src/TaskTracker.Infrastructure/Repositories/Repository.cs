using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain.Abstractions;

namespace TaskTracker.Infrastructure.Repositories;

internal abstract class Repository<T>(ApplicationDbContext dbContext)
 where T : Entity
{
    protected readonly ApplicationDbContext DbContext = dbContext;

    public virtual async Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public virtual void Add(T entity)
    {
        DbContext.Add(entity);
    }
}