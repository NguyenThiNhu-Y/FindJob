using System.Threading.Tasks;

namespace FindJob.Web.Pages.ManageCandidates.ManageCandidate
{
    public class IndexModel : FindJobPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
