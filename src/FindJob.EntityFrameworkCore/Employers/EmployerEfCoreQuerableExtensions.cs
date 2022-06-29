using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Employers
{
    public static class EmployerEfCoreQueryableExtensions
    {
        public static IQueryable<Employer> IncludeDetails(this IQueryable<Employer> queryable, bool include = true)
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