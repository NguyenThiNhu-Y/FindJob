using Volo.Abp.Modularity;

namespace FindJob
{
    [DependsOn(
        typeof(FindJobApplicationModule),
        typeof(FindJobDomainTestModule)
        )]
    public class FindJobApplicationTestModule : AbpModule
    {

    }
}