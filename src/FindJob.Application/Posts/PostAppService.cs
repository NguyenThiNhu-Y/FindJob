using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Employers;
using FindJob.Fields;
using FindJob.Permissions;
using FindJob.Posts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

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
        private readonly IFieldRepository _fieldRepository;
        private readonly IdentityUserAppService _userAppService;
        private readonly IIdentityUserRepository _userRepository;
        private readonly IEmployerRepository _employerRepository;

        public PostAppService(
            IPostRepository repository, 
            IFieldRepository fieldRepository, 
            IdentityUserAppService userAppService,
            IIdentityUserRepository userRepository,
            IEmployerRepository employerRepository) : base(repository)
        {
            _repository = repository;
            _fieldRepository = fieldRepository;
            _userAppService = userAppService;
            _userRepository = userRepository;
            _employerRepository = employerRepository;
        }


        public async Task<PagedResultDto<PostDto>> GetListPostAsync(GetInputPost input)
        {

            var posts = await _repository.GetListPostAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );
            
            List<PostDto> postsDto = new List<PostDto>();
            List<PostDto> postsEmployerDto = new List<PostDto>();

            foreach (var item in posts)
            {
                
                PostDto postDto = new PostDto();
                postDto.Id = item.Id;
                postDto.IdUser = item.IdUser;
                postDto.IdField = item.IdField;
                postDto.Content = item.Content;
                postDto.Status = item.Status;
                if (item.IdField != Guid.Empty)
                {
                    postDto.FieldName = (await _fieldRepository.FindAsync((Guid)item.IdField)).Name;
                }
                else
                {
                    postDto.FieldName = "";
                }
                if(postDto.IdUser != Guid.Empty)
                {
                    var user = await _userRepository.FindAsync(postDto.IdUser);
                    var employer = await _employerRepository.FindEmployerByIdUser(user.Id);
                    postDto.FullName = employer.CompanyName;
                }
                if (CurrentUser.UserName != "admin")
                {
                    if(postDto.IdUser == CurrentUser.Id)
                    {
                        postsEmployerDto.Add(postDto);
                    }
                }
                postsDto.Add(postDto);


            }

            var totalCount = input.Filter == null
                ? await _repository.CountAsync()
                : await _repository.CountAsync(
                    field => field.IdUser.ToString().Contains(input.Filter));
            if (CurrentUser.UserName != "admin")
            {
                return new PagedResultDto<PostDto>(
                    totalCount,
                    postsEmployerDto
                );
            }
            return new PagedResultDto<PostDto>(
                totalCount,
                postsDto
            );
        }

        public async Task<bool> ChangeStatus(Guid Id)
        {
            if(CurrentUser.UserName != "admin")
            {
                return false;
            }
            var post = await _repository.FindAsync(Id);
            post.Status = !post.Status;
            await _repository.UpdateAsync(post);
            return true;
        }
    } 
}
