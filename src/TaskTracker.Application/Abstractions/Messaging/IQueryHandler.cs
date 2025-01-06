using MediatR;
using TaskTracker.Domain.Abstractions;

namespace TaskTracker.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;