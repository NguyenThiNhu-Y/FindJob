using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace FindJob.CVs
{
    public class CVAppServiceTests : FindJobApplicationTestBase
    {
        private readonly ICVAppService _cVAppService;

        public CVAppServiceTests()
        {
            _cVAppService = GetRequiredService<ICVAppService>();
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
