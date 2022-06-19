using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace FindJob.CVs
{
    public class CVsAppServiceTests : FindJobApplicationTestBase
    {
        private readonly ICVsAppService _cVsAppService;

        public CVsAppServiceTests()
        {
            _cVsAppService = GetRequiredService<ICVsAppService>();
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
