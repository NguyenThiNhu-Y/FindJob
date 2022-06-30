using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FindJob.Notifies
{
    public class NotifyRepository : EfCoreRepository<FindJobDbContext, Notify, Guid>, INotifyRepository
    {
        public NotifyRepository(IDbContextProvider<FindJobDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }
        public async Task<List<Notify>> GetListNotifyAsync(int skipCount, int maxResultCount, string sorting = null, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!string.IsNullOrWhiteSpace(filter), x=>x.Content.Contains(filter))
                //.OrderBy(sorting!=null? sorting: "CreationTime")
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}