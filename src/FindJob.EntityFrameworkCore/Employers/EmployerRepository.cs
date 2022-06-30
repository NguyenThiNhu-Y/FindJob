using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FindJob.Employers
{
    public class EmployerRepository : EfCoreRepository<FindJobDbContext, Employer, Guid>, IEmployerRepository
    {
        public EmployerRepository(IDbContextProvider<FindJobDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Employer> FindEmployerByIdUser(Guid IdUser)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(x => x.IdUser == IdUser).FirstOrDefaultAsync();
        }

        public async Task<List<Employer>> GetListEmployerAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                
                //.OrderBy(sorting!=null? sorting: "CreationTime")
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}