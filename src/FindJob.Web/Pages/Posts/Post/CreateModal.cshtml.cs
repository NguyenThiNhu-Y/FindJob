using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Posts;
using FindJob.Posts.Dtos;
using FindJob.Web.Pages.Posts.Post.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using FindJob.Fields;
using System.Linq;

namespace FindJob.Web.Pages.Posts.Post
{
    public class CreateModalModel : FindJobPageModel
    {
        [BindProperty]
        public CreateEditPostViewModel ViewModel { get; set; }
        public List<SelectListItem> ListIdParent { get; set; }


        private readonly IPostAppService _service;
        private readonly IFieldRepository _fieldRepository;


        public CreateModalModel(IPostAppService service, IFieldRepository fieldRepository)
        {
            _service = service;
            _fieldRepository = fieldRepository;
        }
        public virtual async Task OnGetAsync()
        {
            ListIdParent = new List<SelectListItem>();
            ListIdParent.Add(new SelectListItem
            {
                Text = L["Choose"],
                Value = ""
            });
            var items = (await _fieldRepository.GetListAsync());
            if (items.Count > 0)
            {
                ListIdParent.AddRange(
                (items.Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                }).ToList()
            ));
            }


        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditPostViewModel, CreateUpdatePostDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}