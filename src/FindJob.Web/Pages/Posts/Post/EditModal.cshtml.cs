using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Posts;
using FindJob.Posts.Dtos;
using FindJob.Web.Pages.Posts.Post.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using FindJob.Fields;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;

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
        public List<SelectListItem> ListIdParent { get; set; }


        private readonly IFieldRepository _fieldRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EditModalModel(IPostAppService service, IFieldRepository fieldRepository, IWebHostEnvironment hostEnvironment)
        {
            _service = service;
            _fieldRepository = fieldRepository;
            _hostEnvironment = hostEnvironment;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<PostDto, CreateEditPostViewModel>(dto);
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

        public virtual async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            var dto = ObjectMapper.Map<CreateEditPostViewModel, CreateUpdatePostDto>(ViewModel);
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                var wwwRootPath = _hostEnvironment.WebRootPath;
                var filename = "Post" + DateTime.Now.ToString("yymmssfff") + extension;
                var image = DefaultFile.UploadFile + filename;
                var path = Path.Combine(wwwRootPath + image);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                dto.FileName = filename;
            }
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}