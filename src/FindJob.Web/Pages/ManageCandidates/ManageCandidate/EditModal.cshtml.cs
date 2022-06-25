using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.ManageCandidates;
using FindJob.ManageCandidates.Dtos;
using FindJob.Web.Pages.ManageCandidates.ManageCandidate.ViewModels;

namespace FindJob.Web.Pages.ManageCandidates.ManageCandidate
{
    public class EditModalModel : FindJobPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditManageCandidateViewModel ViewModel { get; set; }

        private readonly IManageCandidateAppService _service;

        public EditModalModel(IManageCandidateAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<ManageCandidateDto, CreateEditManageCandidateViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditManageCandidateViewModel, CreateUpdateManageCandidateDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}