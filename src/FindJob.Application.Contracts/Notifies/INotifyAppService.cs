using System;
using System.Threading.Tasks;
using FindJob.Notifies.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.Notifies
{
    public interface INotifyAppService :
        ICrudAppService< 
            NotifyDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateNotifyDto,
            CreateUpdateNotifyDto>
    {
        Task<PagedResultDto<NotifyDto>> GetListNotifyAsync(GetInputNotify input);
    }
}