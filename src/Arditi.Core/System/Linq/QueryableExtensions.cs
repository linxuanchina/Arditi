﻿using Arditi;

namespace System.Linq;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> Paging<TEntity>(this IQueryable<TEntity> queryable,
        int index, int size, out int total)
    {
        ExceptionHelper.Range(index, nameof(index), 1);
        ExceptionHelper.Range(size, nameof(size), 1);
        total = queryable.Count();
        return queryable.Skip(size * (index - 1)).Take(size);
    }
}
