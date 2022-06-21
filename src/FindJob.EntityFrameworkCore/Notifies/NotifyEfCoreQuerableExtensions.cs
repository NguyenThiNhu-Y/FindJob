using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Notifies
{
    public static class NotifyEfCoreQueryableExtensions
    {
        public static IQueryable<Notify> IncludeDetails(this IQueryable<Notify> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                // .Include(x => x.xxx) // TODO: AbpHelper generated
                ;
        }
    }
}