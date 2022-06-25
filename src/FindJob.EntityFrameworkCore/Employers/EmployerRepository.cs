using System;
using FindJob.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FindJob.Employers
{
    public class EmployerRepository : EfCoreRepository<FindJobDbContext, Employer, Guid>, IEmployerRepository
    {
        public EmployerRepository(IDbContextProvider<FindJobDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}