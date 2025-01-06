using MediatR;
using TaskTracker.Domain.Abstractions;

namespace TaskTracker.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}