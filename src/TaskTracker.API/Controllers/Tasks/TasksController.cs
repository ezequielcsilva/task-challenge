using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Abstractions.Messaging;
using TaskTracker.Application.Tasks.CreateTask;
using TaskTracker.Application.Tasks.GetTasks;

namespace TaskTracker.API.Controllers.Tasks;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/tasks")]
public class TasksController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTasks([FromQuery] PaginatedOptions options, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetAllTasksQuery(options), cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest newTask, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new CreateTaskCommand(newTask), cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Errors);
    }
}