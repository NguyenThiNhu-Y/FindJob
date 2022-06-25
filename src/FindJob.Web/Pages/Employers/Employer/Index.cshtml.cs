using System.Threading.Tasks;

namespace FindJob.Web.Pages.Employers.Employer
{
    public class IndexModel : FindJobPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
