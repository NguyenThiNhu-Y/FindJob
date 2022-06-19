using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.CVs;
using FindJob.CVs.Dtos;
using FindJob.Web.Pages.CVs.CV.ViewModels;

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

        public EditModalModel(ICVAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CVDto, CreateEditCVViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCVViewModel, CreateUpdateCVDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}