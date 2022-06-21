using System;
using System.Threading.Tasks;
using FindJob.CurriculumVitaes;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace FindJob.EntityFrameworkCore.CurriculumVitaes
{
    public class CurriculumVitaeRepositoryTests : FindJobEntityFrameworkCoreTestBase
    {
        private readonly ICurriculumVitaeRepository _curriculumVitaeRepository;

        public CurriculumVitaeRepositoryTests()
        {
            _curriculumVitaeRepository = GetRequiredService<ICurriculumVitaeRepository>();
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
