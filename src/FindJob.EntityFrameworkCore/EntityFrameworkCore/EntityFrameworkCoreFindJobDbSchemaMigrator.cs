using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FindJob.Data;
using Volo.Abp.DependencyInjection;

namespace FindJob.EntityFrameworkCore
{
    public class EntityFrameworkCoreFindJobDbSchemaMigrator
        : IFindJobDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreFindJobDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the FindJobDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<FindJobDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
