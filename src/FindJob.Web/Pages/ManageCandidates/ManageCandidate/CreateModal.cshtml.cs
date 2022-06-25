using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.ManageCandidates;
using FindJob.ManageCandidates.Dtos;
using FindJob.Web.Pages.ManageCandidates.ManageCandidate.ViewModels;

namespace FindJob.Web.Pages.ManageCandidates.ManageCandidate
{
    public class CreateModalModel : FindJobPageModel
    {
        [BindProperty]
        public CreateEditManageCandidateViewModel ViewModel { get; set; }

        private readonly IManageCandidateAppService _service;

        public CreateModalModel(IManageCandidateAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditManageCandidateViewModel, CreateUpdateManageCandidateDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}