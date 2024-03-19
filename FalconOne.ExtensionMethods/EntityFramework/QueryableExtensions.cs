using FalconOne.Helpers.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.Extensions.EntityFramework
{
    public static class QueryableExtensions
    {
        public async static Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, PageParams model)
        {
            var totalItems = await query.CountAsync();

            var items = await query.Skip(((model.PageIndex + 1) - 1) * model.PageSize)
                                   .Take(model.PageSize)
                                   .ToListAsync();

            return new PagedList<T>(items, model, totalItems);
        }
    }
}
