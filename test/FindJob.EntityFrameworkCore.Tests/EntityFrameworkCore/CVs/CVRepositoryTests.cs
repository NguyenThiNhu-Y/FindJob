using System;
using System.Threading.Tasks;
using FindJob.CVs;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace FindJob.EntityFrameworkCore.CVs
{
    public class CVRepositoryTests : FindJobEntityFrameworkCoreTestBase
    {
        private readonly ICVRepository _cVRepository;

        public CVRepositoryTests()
        {
            _cVRepository = GetRequiredService<ICVRepository>();
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
