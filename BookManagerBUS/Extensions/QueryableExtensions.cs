using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagerBUS.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<Pagination<T>> GetPagedAsync<T>(this IQueryable<T> query, int currentPage, int pageSize) where T : class
        {
            Pagination<T> result = new Pagination<T>(await query.CountAsync(), currentPage, pageSize);
            int count = (currentPage - 1) * pageSize;
            Pagination<T> pagination = result;
            pagination.Content = await query.Skip(count).Take(pageSize).ToListAsync();     
            return result;
        }

    }
}
