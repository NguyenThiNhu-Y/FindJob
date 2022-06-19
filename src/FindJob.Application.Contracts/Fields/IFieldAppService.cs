using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Fields.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.Fields
{
    public interface IFieldAppService :
        ICrudAppService< 
            FieldDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateFieldDto,
            CreateUpdateFieldDto>
    {
        Task<PagedResultDto<FieldDto>> GetListFieldAsync(GetInputField input);

    }
}