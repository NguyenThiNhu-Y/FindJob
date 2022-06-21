using System;
using System.Threading.Tasks;
using FindJob.Notifies;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace FindJob.EntityFrameworkCore.Notifies
{
    public class NotifyRepositoryTests : FindJobEntityFrameworkCoreTestBase
    {
        private readonly INotifyRepository _notifyRepository;

        public NotifyRepositoryTests()
        {
            _notifyRepository = GetRequiredService<INotifyRepository>();
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
