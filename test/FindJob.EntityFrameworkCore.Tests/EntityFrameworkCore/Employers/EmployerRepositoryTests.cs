using System;
using System.Threading.Tasks;
using FindJob.Employers;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace FindJob.EntityFrameworkCore.Employers
{
    public class EmployerRepositoryTests : FindJobEntityFrameworkCoreTestBase
    {
        private readonly IEmployerRepository _employerRepository;

        public EmployerRepositoryTests()
        {
            _employerRepository = GetRequiredService<IEmployerRepository>();
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
