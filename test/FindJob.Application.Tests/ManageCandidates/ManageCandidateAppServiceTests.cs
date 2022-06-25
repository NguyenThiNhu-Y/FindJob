using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace FindJob.ManageCandidates
{
    public class ManageCandidateAppServiceTests : FindJobApplicationTestBase
    {
        private readonly IManageCandidateAppService _manageCandidateAppService;

        public ManageCandidateAppServiceTests()
        {
            _manageCandidateAppService = GetRequiredService<IManageCandidateAppService>();
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
