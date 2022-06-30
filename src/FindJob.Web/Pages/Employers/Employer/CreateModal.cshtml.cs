using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindJob.Employers;
using FindJob.Employers.Dtos;
using FindJob.Web.Pages.Employers.Employer.ViewModels;
using Volo.Abp.Identity;
using System;

namespace FindJob.Web.Pages.Employers.Employer
{
    public class CreateModalModel : FindJobPageModel
    {
        [BindProperty]
        public CreateEditEmployerViewModel ViewModel { get; set; }
        
        [BindProperty]
        public IdentityUserCreateDto UserDto { get; set; }

        private readonly IEmployerAppService _service;
        private readonly IdentityUserAppService _userService;
        private readonly IIdentityRoleRepository _roleRepository;
        private readonly IIdentityRoleAppService _roleAppService;

        public CreateModalModel(
            IEmployerAppService service, 
            IdentityUserAppService userService, 
            IIdentityRoleRepository roleRepository,
            IIdentityRoleAppService roleAppService)
        {
            _service = service;
            _userService = userService;
            _roleRepository = roleRepository;
            _roleAppService = roleAppService;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            
            var dto = ObjectMapper.Map<CreateEditEmployerViewModel, CreateUpdateEmployerDto>(ViewModel);

            var role = await _roleRepository.FindByNormalizedNameAsync("NHÀ TUYỂN DỤNG");
            //foreach(var role in roles)
            //    if(role.Name == "Nhà tuyển dụng")
            //        UserDto.RoleNames[0] = role.Name;
            UserDto.RoleNames = new string[1];
            UserDto.RoleNames[0] = "Nhà tuyển dụng";
            var user = await _userService.CreateAsync(UserDto);
            dto.IdUser = user.Id;
            await _service.CreateAsync(dto);
            
            return NoContent();
        }
    }
}