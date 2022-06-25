using System;
using FindJob.ManageCandidates.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.ManageCandidates
{
    public interface IManageCandidateAppService :
        ICrudAppService< 
            ManageCandidateDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateManageCandidateDto,
            CreateUpdateManageCandidateDto>
    {

    }
}