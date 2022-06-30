using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FindJob.Web.Pages
{
    public class IndexModel : FindJobPageModel
    {
        public async Task<IActionResult> OnGet()
        {
            var currentUser = CurrentUser.Id;
            if (currentUser == null)
            {
                return Redirect("/Client/Index");
            }
            return Page();
        }
    }
}