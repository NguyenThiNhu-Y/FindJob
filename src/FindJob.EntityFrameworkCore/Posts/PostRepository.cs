using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FindJob.Posts
{
    public class PostRepository : EfCoreRepository<FindJobDbContext, Post, Guid>, IPostRepository
    {
        public PostRepository(IDbContextProvider<FindJobDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Post>> GetListPostAsync(int skipCount, int maxResultCount, string sorting = null, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    author => author.IdUser.ToString().Contains(filter)
                 )
                //.OrderBy(sorting!=null? sorting: "CreationTime")
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}