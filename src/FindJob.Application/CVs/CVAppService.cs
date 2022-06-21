using System;
using FindJob.Permissions;
using FindJob.CVs.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using FindJob.Fields;
using Volo.Abp.Domain.Repositories;

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
        private readonly IFieldRepository _fieldRepository;


        public CVAppService(ICVRepository repository, IFieldRepository fieldRepository) : base(repository)
        {
            _repository = repository;
            _fieldRepository = fieldRepository;
        }

        public async Task<PagedResultDto<CVDto>> GetListCVAsync(GetInputCV input)
        {
            var CVs = await _repository.GetListCVAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            List<CVDto> CVsDto = new List<CVDto>();

            foreach (var item in CVs)
            {
                CVDto CVDto = new CVDto();
                CVDto.Id = item.Id;
                CVDto.IdUser = item.IdUser;
                CVDto.IdField = item.IdField;
                CVDto.Content = item.Content;
                CVDto.Status = item.Status;
                CVDto.IsRead = item.IsRead;
                if (item.IdField != Guid.Empty)
                {
                    CVDto.FieldName = (await _fieldRepository.FindAsync((Guid)item.IdField)).Name;
                }
                else
                {
                    CVDto.FieldName = "";
                }
                if (CVDto.IdUser != Guid.Empty)
                {
                    CVDto.FullName = CurrentUser.SurName + " " + CurrentUser.Name;
                }
                CVsDto.Add(CVDto);


            }

            var totalCount = input.Filter == null
                ? await _repository.CountAsync()
                : await _repository.CountAsync(
                    field => field.IdUser.ToString().Contains(input.Filter));

            return new PagedResultDto<CVDto>(
                totalCount,
                CVsDto
            );
        }

        public async Task ChangeStatus(Guid Id)
        {
            var CV = await _repository.FindAsync(Id);
            CV.Status = !CV.Status;
            await _repository.UpdateAsync(CV);
        }
    }
}
