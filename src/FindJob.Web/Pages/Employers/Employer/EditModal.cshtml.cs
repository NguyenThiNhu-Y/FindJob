using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Employers;
using FindJob.Employers.Dtos;
using FindJob.Web.Pages.Employers.Employer.ViewModels;

namespace FindJob.Web.Pages.Employers.Employer
{
    public class EditModalModel : FindJobPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditEmployerViewModel ViewModel { get; set; }

        private readonly IEmployerAppService _service;

        public EditModalModel(IEmployerAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<EmployerDto, CreateEditEmployerViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditEmployerViewModel, CreateUpdateEmployerDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}