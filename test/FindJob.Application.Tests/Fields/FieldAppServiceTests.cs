using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace FindJob.Fields
{
    public class FieldAppServiceTests : FindJobApplicationTestBase
    {
        private readonly IFieldAppService _fieldAppService;

        public FieldAppServiceTests()
        {
            _fieldAppService = GetRequiredService<IFieldAppService>();
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
