using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Posts;
using FindJob.Posts.Dtos;
using FindJob.Web.Pages.Posts.Post.ViewModels;

namespace FindJob.Web.Pages.Posts.Post
{
    public class CreateModalModel : FindJobPageModel
    {
        [BindProperty]
        public CreateEditPostViewModel ViewModel { get; set; }

        private readonly IPostAppService _service;

        public CreateModalModel(IPostAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditPostViewModel, CreateUpdatePostDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}