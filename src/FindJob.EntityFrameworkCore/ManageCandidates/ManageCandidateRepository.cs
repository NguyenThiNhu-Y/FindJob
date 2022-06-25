using System;
using FindJob.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FindJob.ManageCandidates
{
    public class ManageCandidateRepository : EfCoreRepository<FindJobDbContext, ManageCandidate, Guid>, IManageCandidateRepository
    {
        public ManageCandidateRepository(IDbContextProvider<FindJobDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}