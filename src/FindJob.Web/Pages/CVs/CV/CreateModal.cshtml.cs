using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.CVs;
using FindJob.CVs.Dtos;
using FindJob.Web.Pages.CVs.CV.ViewModels;

namespace FindJob.Web.Pages.CVs.CV
{
    public class CreateModalModel : FindJobPageModel
    {
        [BindProperty]
        public CreateEditCVViewModel ViewModel { get; set; }

        private readonly ICVAppService _service;

        public CreateModalModel(ICVAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCVViewModel, CreateUpdateCVDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}