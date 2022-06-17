using System;
using System.Threading.Tasks;
using FindJob.Posts;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace FindJob.EntityFrameworkCore.Posts
{
    public class PostRepositoryTests : FindJobEntityFrameworkCoreTestBase
    {
        private readonly IPostRepository _postRepository;

        public PostRepositoryTests()
        {
            _postRepository = GetRequiredService<IPostRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
        */
    }
}
