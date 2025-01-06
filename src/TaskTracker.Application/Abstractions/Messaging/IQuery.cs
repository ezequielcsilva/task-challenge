using MediatR;
using TaskTracker.Domain.Abstractions;

namespace TaskTracker.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>, IBaseQuery;

public interface IBaseQuery;