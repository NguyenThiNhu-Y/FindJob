using System;
using System.Threading.Tasks;
using FindJob.Employers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.Employers
{
    public interface IEmployerAppService :
        ICrudAppService< 
            EmployerDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateEmployerDto,
            CreateUpdateEmployerDto>
    {
        Task<string[]> top3Employer();
        Task<PagedResultDto<EmployerDto>> GetListEmployerAsync(GetInputEmployer input);

    }
}