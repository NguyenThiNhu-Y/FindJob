using System;
using System.Threading.Tasks;
using FindJob.Fields;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace FindJob.EntityFrameworkCore.Fields
{
    public class FieldRepositoryTests : FindJobEntityFrameworkCoreTestBase
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldRepositoryTests()
        {
            _fieldRepository = GetRequiredService<IFieldRepository>();
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
