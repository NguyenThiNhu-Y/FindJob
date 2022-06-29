using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Employers;
using FindJob.Employers.Dtos;
using FindJob.Web.Pages.Employers.Employer.ViewModels;
using Volo.Abp.Identity;

namespace FindJob.Web.Pages.Employers.Employer
{
    public class CreateModalModel : FindJobPageModel
    {
        [BindProperty]
        public CreateEditEmployerViewModel ViewModel { get; set; }

        private readonly IEmployerAppService _service;
        private readonly IdentityUserAppService _userService;

        public CreateModalModel(IEmployerAppService service, IdentityUserAppService userService)
        {
            _service = service;
            _userService = userService;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            var dto = ObjectMapper.Map<CreateEditEmployerViewModel, CreateUpdateEmployerDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}