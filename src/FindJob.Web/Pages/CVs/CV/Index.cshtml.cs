using System.Threading.Tasks;

namespace FindJob.Web.Pages.CVs.CV
{
    public class IndexModel : FindJobPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
