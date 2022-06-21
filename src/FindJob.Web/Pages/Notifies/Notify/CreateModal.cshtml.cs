using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Notifies;
using FindJob.Notifies.Dtos;
using FindJob.Web.Pages.Notifies.Notify.ViewModels;

namespace FindJob.Web.Pages.Notifies.Notify
{
    public class CreateModalModel : FindJobPageModel
    {
        [BindProperty]
        public CreateEditNotifyViewModel ViewModel { get; set; }

        private readonly INotifyAppService _service;

        public CreateModalModel(INotifyAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditNotifyViewModel, CreateUpdateNotifyDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}