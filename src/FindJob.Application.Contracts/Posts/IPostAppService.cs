using System;
using System.Threading.Tasks;
using FindJob.Posts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.Posts
{
    public interface IPostAppService :
        ICrudAppService< 
            PostDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdatePostDto,
            CreateUpdatePostDto>
    {
        Task<PagedResultDto<PostDto>> GetListPostAsync(GetInputPost input);
        Task<bool> ChangeStatus(Guid Id);
    }
}