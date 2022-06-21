using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace FindJob.CurriculumVitaes
{
    public class CurriculumVitaeAppServiceTests : FindJobApplicationTestBase
    {
        private readonly ICurriculumVitaeAppService _curriculumVitaeAppService;

        public CurriculumVitaeAppServiceTests()
        {
            _curriculumVitaeAppService = GetRequiredService<ICurriculumVitaeAppService>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            // Arrange

            // Act

            // Assert
        }
        */
    }
}
