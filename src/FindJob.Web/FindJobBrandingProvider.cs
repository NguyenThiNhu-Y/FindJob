using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FindJob.Web
{
    [Dependency(ReplaceServices = true)]
    public class FindJobBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "FindJob";
    }
}
