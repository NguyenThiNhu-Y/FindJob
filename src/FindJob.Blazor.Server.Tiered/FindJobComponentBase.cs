using FindJob.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FindJob.Blazor.Server.Tiered
{
    public abstract class FindJobComponentBase : AbpComponentBase
    {
        protected FindJobComponentBase()
        {
            LocalizationResource = typeof(FindJobResource);
        }
    }
}
