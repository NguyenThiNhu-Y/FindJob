using System;
using FindJob.Permissions;
using FindJob.Posts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FindJob.Posts
{
    public class PostAppService : CrudAppService<Post, PostDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePostDto, CreateUpdatePostDto>,
        IPostAppService
    {
        protected override string GetPolicyName { get; set; } = FindJobPermissions.Post.Default;
        protected override string GetListPolicyName { get; set; } = FindJobPermissions.Post.Default;
        protected override string CreatePolicyName { get; set; } = FindJobPermissions.Post.Create;
        protected override string UpdatePolicyName { get; set; } = FindJobPermissions.Post.Update;
        protected override string DeletePolicyName { get; set; } = FindJobPermissions.Post.Delete;

        private readonly IPostRepository _repository;
        
        public PostAppService(IPostRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
