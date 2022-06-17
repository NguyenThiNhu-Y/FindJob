using FindJob.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FindJob.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class FindJobController : AbpController
    {
        protected FindJobController()
        {
            LocalizationResource = typeof(FindJobResource);
        }
    }
}