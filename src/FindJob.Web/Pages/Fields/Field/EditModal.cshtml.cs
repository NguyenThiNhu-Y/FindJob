using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Fields;
using FindJob.Fields.Dtos;
using FindJob.Web.Pages.Fields.Field.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FindJob.Web.Pages.Fields.Field
{
    public class EditModalModel : FindJobPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditFieldViewModel ViewModel { get; set; }

        [BindProperty]
        public List<SelectListItem> ListIdParent { get; set; }


        private readonly IFieldAppService _service;
        private readonly IFieldRepository _repository;


        public EditModalModel(IFieldAppService service, IFieldRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<FieldDto, CreateEditFieldViewModel>(dto);
            ListIdParent = new List<SelectListItem>();
            ListIdParent.Add(new SelectListItem
            {
                Text = L["Choose"],
                Value = ""
            });
            var items = (await _repository.GetListAsync());
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
            var dto = ObjectMapper.Map<CreateEditFieldViewModel, CreateUpdateFieldDto>(ViewModel);
            await _service.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}