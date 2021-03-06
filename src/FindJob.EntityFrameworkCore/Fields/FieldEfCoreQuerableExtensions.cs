using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Fields
{
    public static class FieldEfCoreQueryableExtensions
    {
        public static IQueryable<Field> IncludeDetails(this IQueryable<Field> queryable, bool include = true)
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