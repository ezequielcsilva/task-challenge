using FluentValidation;

namespace TaskTracker.Application.Tasks.CreateTask;

internal sealed class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
        RuleFor(c => c.Request.Name)
            .NotEmpty();

        RuleFor(c => c.Request.Description)
             .NotEmpty();
    }
}