using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FindJob.Data
{
    /* This is used if database provider does't define
     * IFindJobDbSchemaMigrator implementation.
     */
    public class NullFindJobDbSchemaMigrator : IFindJobDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}