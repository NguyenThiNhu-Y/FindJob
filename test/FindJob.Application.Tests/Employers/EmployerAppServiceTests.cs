using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace FindJob.Employers
{
    public class EmployerAppServiceTests : FindJobApplicationTestBase
    {
        private readonly IEmployerAppService _employerAppService;

        public EmployerAppServiceTests()
        {
            _employerAppService = GetRequiredService<IEmployerAppService>();
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
