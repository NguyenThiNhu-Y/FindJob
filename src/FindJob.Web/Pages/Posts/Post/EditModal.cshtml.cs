using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Posts;
using FindJob.Posts.Dtos;
using FindJob.Web.Pages.Posts.Post.ViewModels;

namespace FindJob.Web.Pages.Posts.Post
{
    public class EditModalModel : FindJobPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditPostViewModel ViewModel { get; set; }

        private readonly IPostAppService _service;

        public EditModalModel(IPostAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<PostDto, CreateEditPostViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditPostViewModel, CreateUpdatePostDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}