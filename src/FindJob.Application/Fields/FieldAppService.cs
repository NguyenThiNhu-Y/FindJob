using System;
using FindJob.Permissions;
using FindJob.Fields.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FindJob.Fields
{
    public class FieldAppService : CrudAppService<Field, FieldDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateFieldDto, CreateUpdateFieldDto>,
        IFieldAppService
    {
        protected override string GetPolicyName { get; set; } = FindJobPermissions.Field.Default;
        protected override string GetListPolicyName { get; set; } = FindJobPermissions.Field.Default;
        protected override string CreatePolicyName { get; set; } = FindJobPermissions.Field.Create;
        protected override string UpdatePolicyName { get; set; } = FindJobPermissions.Field.Update;
        protected override string DeletePolicyName { get; set; } = FindJobPermissions.Field.Delete;

        private readonly IFieldRepository _repository;
        
        public FieldAppService(IFieldRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<PagedResultDto<FieldDto>> GetListFieldAsync(GetInputField input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Field.Name);
            }

            var fields = await _repository.GetListFieldAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            List<FieldDto> fieldsDto = new List<FieldDto>();
            //fields.Select(t => new FieldDto
            //{
            //    Id = t.Id,
            //    Name = t.Name,
            //    IdParentField = t.IdParentField,
            //    //ParentField = (fields.Select(e=>e).Where(e=>e.Id == t.IdParentField)).Single().Name
            //}).ToList();
            foreach(var item in fields)
            {
                FieldDto fieldDto = new FieldDto();
                fieldDto.Id = item.Id;
                fieldDto.Name = item.Name;
                fieldDto.IdParentField = item.IdParentField;
                if (item.IdParentField.HasValue)
                {
                    fieldDto.ParentField = (await _repository.FindAsync((Guid)item.IdParentField)).Name;
                }
                else
                {
                    fieldDto.ParentField = "";
                }
                fieldsDto.Add(fieldDto);


            }

            var totalCount = input.Filter == null
                ? await _repository.CountAsync()
                : await _repository.CountAsync(
                    field => field.Name.Contains(input.Filter));

            return new PagedResultDto<FieldDto>(
                totalCount,
                fieldsDto
            );
        }
    }
}
