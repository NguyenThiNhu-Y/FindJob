using System;
using System.Threading.Tasks;
using FindJob.CVs;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace FindJob.EntityFrameworkCore.CVs
{
    public class CVsRepositoryTests : FindJobEntityFrameworkCoreTestBase
    {
        private readonly ICVsRepository _cVsRepository;

        public CVsRepositoryTests()
        {
            _cVsRepository = GetRequiredService<ICVsRepository>();
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
