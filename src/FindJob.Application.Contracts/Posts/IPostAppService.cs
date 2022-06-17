using System;
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

    }
}