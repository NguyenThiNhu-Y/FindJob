using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Posts;
using FindJob.Posts.Dtos;
using FindJob.Web.Pages.Posts.Post.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using FindJob.Fields;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace FindJob.Web.Pages.Posts.Post
{
    public class CreateModalModel : FindJobPageModel
    {
        [BindProperty]
        public CreateEditPostViewModel ViewModel { get; set; }
        public List<SelectListItem> ListIdParent { get; set; }


        private readonly IPostAppService _service;
        private readonly IFieldRepository _fieldRepository;
        private readonly IWebHostEnvironment _hostEnvironment;


        public CreateModalModel(IPostAppService service, IFieldRepository fieldRepository, IWebHostEnvironment hostEnvironment)
        {
            _service = service;
            _fieldRepository = fieldRepository;
            _hostEnvironment = hostEnvironment;
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
            dto.IdUser = (Guid)CurrentUser.Id;
            await _service.CreateAsync(dto);
            return RedirectToAction("Post", "Posts");
        }
    }
}