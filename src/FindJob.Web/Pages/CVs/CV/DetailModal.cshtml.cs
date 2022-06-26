using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.CVs;
using FindJob.CVs.Dtos;
using FindJob.Fields;
using FindJob.Web.Pages.CVs.CV.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp;

namespace FindJob.Web.Pages.CVs.CV
{
    public class DetailModalModel : FindJobPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCVViewModel ViewModel { get; set; }

        private readonly ICVAppService _service;
        private readonly ICVRepository _repository;
        public List<SelectListItem> ListIdParent { get; set; }


        private readonly IFieldRepository _fieldRepository;
        public DetailModalModel(ICVAppService service, IFieldRepository fieldRepository, ICVRepository repository)
        {
            _service = service;
            _fieldRepository = fieldRepository;
            _repository = repository;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _repository.FindAsync(Id);

            if(dto == null)
            {
                throw new UserFriendlyException(L["CVNotExist"]);
            }
            ViewModel = ObjectMapper.Map<FindJob.CVs.CV, CreateEditCVViewModel>(dto);
            ListIdParent = new List<SelectListItem>();
            ListIdParent.Add(new SelectListItem
            {
                Text = L["Choose"],
                Value = ""
            });
            var items = (await _fieldRepository.GetListAsync());
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
        public virtual async Task OnPostAsync()
        {

        }

    }
}
