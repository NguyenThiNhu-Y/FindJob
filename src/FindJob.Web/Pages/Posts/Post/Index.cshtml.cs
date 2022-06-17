using System.Threading.Tasks;

namespace FindJob.Web.Pages.Posts.Post
{
    public class IndexModel : FindJobPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
