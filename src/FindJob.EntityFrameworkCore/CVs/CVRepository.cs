using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FindJob.CVs
{
    public class CVRepository : EfCoreRepository<FindJobDbContext, CV, Guid>, ICVRepository
    {
        public CVRepository(IDbContextProvider<FindJobDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<CV>> GetListCVAsync(int skipCount, int maxResultCount, string sorting = null, string filter = null, Guid? idField = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(idField.HasValue, x=>x.IdField==idField)
                //.OrderBy(sorting != null ? sorting : "CreateDate")
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}