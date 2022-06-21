using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace FindJob.Notifies
{
    public class NotifyAppServiceTests : FindJobApplicationTestBase
    {
        private readonly INotifyAppService _notifyAppService;

        public NotifyAppServiceTests()
        {
            _notifyAppService = GetRequiredService<INotifyAppService>();
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
