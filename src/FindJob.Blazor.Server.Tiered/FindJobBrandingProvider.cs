using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FindJob.Blazor.Server.Tiered
{
    [Dependency(ReplaceServices = true)]
    public class FindJobBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "FindJob";
    }
}
