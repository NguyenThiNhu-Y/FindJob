using System;
using FindJob.Permissions;
using FindJob.CVs.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.CVs
{
    public class CVAppService : CrudAppService<CV, CVDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCVDto, CreateUpdateCVDto>,
        ICVAppService
    {
        protected override string GetPolicyName { get; set; } = FindJobPermissions.CV.Default;
        protected override string GetListPolicyName { get; set; } = FindJobPermissions.CV.Default;
        protected override string CreatePolicyName { get; set; } = FindJobPermissions.CV.Create;
        protected override string UpdatePolicyName { get; set; } = FindJobPermissions.CV.Update;
        protected override string DeletePolicyName { get; set; } = FindJobPermissions.CV.Delete;

        private readonly ICVRepository _repository;
        
        public CVAppService(ICVRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
