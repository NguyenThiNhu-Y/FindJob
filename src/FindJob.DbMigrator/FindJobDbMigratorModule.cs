using FindJob.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace FindJob.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(FindJobEntityFrameworkCoreModule),
        typeof(FindJobApplicationContractsModule)
        )]
    public class FindJobDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
