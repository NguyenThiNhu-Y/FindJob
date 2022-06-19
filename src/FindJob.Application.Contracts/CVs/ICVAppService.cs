using System;
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

    }
}