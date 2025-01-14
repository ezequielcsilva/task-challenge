﻿namespace TaskTracker.Application.Abstractions.Data;

public interface IDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}