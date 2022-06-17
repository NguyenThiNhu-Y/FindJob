using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<PagedResultDto<PostDto>> GetListPostAsync(GetInputPost input)
        {
            
            var fields = await _repository.GetListPostAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            List<PostDto> fieldsDto = new List<PostDto>();
            
            foreach (var item in fields)
            {
                PostDto fieldDto = new PostDto();
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
