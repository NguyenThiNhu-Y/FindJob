using System;
using Volo.Abp.Domain.Repositories;

namespace FindJob.Posts
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
    }
}