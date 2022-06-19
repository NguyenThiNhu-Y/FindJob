using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FindJob.CVs
{
    public static class CVEfCoreQueryableExtensions
    {
        public static IQueryable<CV> IncludeDetails(this IQueryable<CV> queryable, bool include = true)
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