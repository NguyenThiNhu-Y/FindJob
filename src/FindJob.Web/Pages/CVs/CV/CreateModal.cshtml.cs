using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.CVs;
using FindJob.CVs.Dtos;
using FindJob.Web.Pages.CVs.CV.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using FindJob.Fields;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace FindJob.Web.Pages.CVs.CV
{
    public class CreateModalModel : FindJobPageModel
    {
        [BindProperty]
        public CreateEditCVViewModel ViewModel { get; set; }

        private readonly ICVAppService _service;
        private readonly IFieldRepository _fieldRepository;
        private readonly IWebHostEnvironment _hostEnvironment;
        public List<SelectListItem> ListIdParent { get; set; }



        public CreateModalModel(ICVAppService service, IFieldRepository fieldRepository, IWebHostEnvironment hostEnvironment)
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
            var dto = ObjectMapper.Map<CreateEditCVViewModel, CreateUpdateCVDto>(ViewModel);

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                var wwwRootPath = _hostEnvironment.WebRootPath;
                var filename = "CV" + DateTime.Now.ToString("yymmssfff") + extension;
                var image = DefaultFile.UploadFile + filename;
                var path = Path.Combine(wwwRootPath + image);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                dto.FileName = filename;
            }
            dto.IdUser = (Guid)CurrentUser.Id;
            dto.IsRead = true;
            await _service.CreateAsync(dto);
            return RedirectToAction("CV", "CVs");
        }
    }
}