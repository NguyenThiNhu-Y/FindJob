using System;
using FindJob.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FindJob.Posts
{
    public class PostRepository : EfCoreRepository<FindJobDbContext, Post, Guid>, IPostRepository
    {
        public PostRepository(IDbContextProvider<FindJobDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}