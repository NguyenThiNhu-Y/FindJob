using System.Threading.Tasks;

namespace FindJob.Web.Pages.Notifies.Notify
{
    public class IndexModel : FindJobPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
