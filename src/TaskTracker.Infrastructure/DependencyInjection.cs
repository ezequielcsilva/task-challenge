using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskTracker.Application.Abstractions.Data;
using TaskTracker.Domain.Tasks;
using TaskTracker.Infrastructure.Repositories;

namespace TaskTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
    this IServiceCollection services)
    {
        AddPersistence(services);

        return services;
    }

    private static void AddPersistence(IServiceCollection services)
    {
        services.AddDbContext<IDbContext, ApplicationDbContext>(opt => opt.UseInMemoryDatabase("tasksDb"));

        services.AddScoped<ITaskItemRepository, TaskItemRepository>();
    }
}