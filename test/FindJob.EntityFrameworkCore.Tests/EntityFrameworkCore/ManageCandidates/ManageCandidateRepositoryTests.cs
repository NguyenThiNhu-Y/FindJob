using System;
using System.Threading.Tasks;
using FindJob.ManageCandidates;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace FindJob.EntityFrameworkCore.ManageCandidates
{
    public class ManageCandidateRepositoryTests : FindJobEntityFrameworkCoreTestBase
    {
        private readonly IManageCandidateRepository _manageCandidateRepository;

        public ManageCandidateRepositoryTests()
        {
            _manageCandidateRepository = GetRequiredService<IManageCandidateRepository>();
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
