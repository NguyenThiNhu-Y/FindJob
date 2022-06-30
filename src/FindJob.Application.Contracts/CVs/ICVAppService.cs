using System;
using System.Threading.Tasks;
using FindJob.CVs.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.CVs
{
    public interface ICVAppService :
        ICrudAppService< 
            CVDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCVDto,
            CreateUpdateCVDto>
    {
        Task<PagedResultDto<CVDto>> GetListCVAsync(GetInputCV input);
        Task ChangeStatus(Guid Id);
        Task<int[]> getNumberCV();
    }
}