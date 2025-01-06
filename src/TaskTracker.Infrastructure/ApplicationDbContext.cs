using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Abstractions.Data;
using TaskTracker.Domain.Tasks;

namespace TaskTracker.Infrastructure;

public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options), IDbContext
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}