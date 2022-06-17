using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace FindJob.Posts
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetListPostAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}