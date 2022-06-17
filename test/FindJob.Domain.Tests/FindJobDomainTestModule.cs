using FindJob.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FindJob
{
    [DependsOn(
        typeof(FindJobEntityFrameworkCoreTestModule)
        )]
    public class FindJobDomainTestModule : AbpModule
    {

    }
}