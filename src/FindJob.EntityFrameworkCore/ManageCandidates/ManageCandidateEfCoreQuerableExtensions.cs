using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FindJob.ManageCandidates
{
    public static class ManageCandidateEfCoreQueryableExtensions
    {
        public static IQueryable<ManageCandidate> IncludeDetails(this IQueryable<ManageCandidate> queryable, bool include = true)
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