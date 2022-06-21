using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Notifies;
using FindJob.Notifies.Dtos;
using FindJob.Web.Pages.Notifies.Notify.ViewModels;

namespace FindJob.Web.Pages.Notifies.Notify
{
    public class EditModalModel : FindJobPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditNotifyViewModel ViewModel { get; set; }

        private readonly INotifyAppService _service;

        public EditModalModel(INotifyAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<NotifyDto, CreateEditNotifyViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditNotifyViewModel, CreateUpdateNotifyDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}