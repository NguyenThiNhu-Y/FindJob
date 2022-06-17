using System;
using System.Collections.Generic;
using System.Text;
using FindJob.Localization;
using Volo.Abp.Application.Services;

namespace FindJob
{
    /* Inherit your application services from this class.
     */
    public abstract class FindJobAppService : ApplicationService
    {
        protected FindJobAppService()
        {
            LocalizationResource = typeof(FindJobResource);
        }
    }
}
