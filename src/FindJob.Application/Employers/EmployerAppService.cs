using System;
using FindJob.Permissions;
using FindJob.Employers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.Employers
{
    public class EmployerAppService : CrudAppService<Employer, EmployerDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEmployerDto, CreateUpdateEmployerDto>,
        IEmployerAppService
    {
        protected override string GetPolicyName { get; set; } = FindJobPermissions.Employer.Default;
        protected override string GetListPolicyName { get; set; } = FindJobPermissions.Employer.Default;
        protected override string CreatePolicyName { get; set; } = FindJobPermissions.Employer.Create;
        protected override string UpdatePolicyName { get; set; } = FindJobPermissions.Employer.Update;
        protected override string DeletePolicyName { get; set; } = FindJobPermissions.Employer.Delete;

        private readonly IEmployerRepository _repository;
        
        public EmployerAppService(IEmployerRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
