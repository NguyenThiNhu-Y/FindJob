using FindJob.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FindJob.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class FindJobPageModel : AbpPageModel
    {
        protected FindJobPageModel()
        {
            LocalizationResourceType = typeof(FindJobResource);
        }
    }
}