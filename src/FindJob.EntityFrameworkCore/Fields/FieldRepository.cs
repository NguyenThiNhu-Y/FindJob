using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Fields
{
    public class FieldRepository : EfCoreRepository<FindJobDbContext, Field, Guid>, IFieldRepository
    {
        public FieldRepository(IDbContextProvider<FindJobDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Field>> GetListFieldAsync(int skipCount, int maxResultCount, string sorting = null, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    author => author.Name.Contains(filter)
                 )
                .OrderBy(sorting != null ? sorting : "CreateDate")
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}