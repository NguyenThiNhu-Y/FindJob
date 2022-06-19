using System;
using FindJob.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FindJob.CVs
{
    public class CVRepository : EfCoreRepository<FindJobDbContext, CV, Guid>, ICVRepository
    {
        public CVRepository(IDbContextProvider<FindJobDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}