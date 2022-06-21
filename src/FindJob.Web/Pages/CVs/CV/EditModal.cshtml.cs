using System;
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

namespace FindJob.Web.Pages.CVs.CV
{
    public class EditModalModel : FindJobPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCVViewModel ViewModel { get; set; }

        private readonly ICVAppService _service;
        public List<SelectListItem> ListIdParent { get; set; }


        private readonly IFieldRepository _fieldRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EditModalModel(ICVAppService service, IFieldRepository fieldRepository, IWebHostEnvironment hostEnvironment)
        {
            _service = service;
            _fieldRepository = fieldRepository;
            _hostEnvironment = hostEnvironment;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CVDto, CreateEditCVViewModel>(dto);
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
            var dto = ObjectMapper.Map<CreateEditCVViewModel, CreateUpdateCVDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}