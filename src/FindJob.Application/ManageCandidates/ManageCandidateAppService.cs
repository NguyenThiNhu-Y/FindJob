using System;
using FindJob.Permissions;
using FindJob.ManageCandidates.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.ManageCandidates
{
    public class ManageCandidateAppService : CrudAppService<ManageCandidate, ManageCandidateDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateManageCandidateDto, CreateUpdateManageCandidateDto>,
        IManageCandidateAppService
    {
        protected override string GetPolicyName { get; set; } = FindJobPermissions.ManageCandidate.Default;
        protected override string GetListPolicyName { get; set; } = FindJobPermissions.ManageCandidate.Default;
        protected override string CreatePolicyName { get; set; } = FindJobPermissions.ManageCandidate.Create;
        protected override string UpdatePolicyName { get; set; } = FindJobPermissions.ManageCandidate.Update;
        protected override string DeletePolicyName { get; set; } = FindJobPermissions.ManageCandidate.Delete;

        private readonly IManageCandidateRepository _repository;
        
        public ManageCandidateAppService(IManageCandidateRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
