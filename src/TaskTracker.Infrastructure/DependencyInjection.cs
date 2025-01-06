using Asp.Versioning;
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

        AddApiVersioning(services);

        AddConfigCors(services);

        return services;
    }

    private static void AddPersistence(IServiceCollection services)
    {
        services.AddDbContext<IDbContext, ApplicationDbContext>(opt => opt.UseInMemoryDatabase("tasksDb"));

        services.AddScoped<ITaskItemRepository, TaskItemRepository>();
    }

    private static void AddApiVersioning(IServiceCollection services)
    {
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });
    }

    private static void AddConfigCors(IServiceCollection services)
    {
        services
            .AddCors(options =>
            {
                options.AddPolicy("TasksTrackerOrigins", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
    }
}