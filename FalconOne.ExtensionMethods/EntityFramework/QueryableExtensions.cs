using FalconOne.Helpers.Helpers;
using Microsoft.EntityFrameworkCore;

namespace FalconOne.Extensions.EntityFramework
{
    public static class QueryableExtensions
    {
        public async static Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, PageParams model)
        {
            var totalItems = await query.CountAsync();

            if(model.Page == 0)
            {
                model.Page = 1;
            }

            var items = await query.Skip(((model.Page) - 1) * model.PageSize)
                                   .Take(model.PageSize)
                                   .ToListAsync();

            return new PagedList<T>(items, model, totalItems);
        }
    }
}
