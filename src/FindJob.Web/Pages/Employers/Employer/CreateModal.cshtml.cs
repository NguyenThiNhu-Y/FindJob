using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Employers;
using FindJob.Employers.Dtos;
using FindJob.Web.Pages.Employers.Employer.ViewModels;

namespace FindJob.Web.Pages.Employers.Employer
{
    public class CreateModalModel : FindJobPageModel
    {
        [BindProperty]
        public CreateEditEmployerViewModel ViewModel { get; set; }

        private readonly IEmployerAppService _service;

        public CreateModalModel(IEmployerAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditEmployerViewModel, CreateUpdateEmployerDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}