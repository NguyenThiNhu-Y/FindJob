using System;
using FindJob.Permissions;
using FindJob.Employers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using FindJob.Posts;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace FindJob.Employers
{
    public class EmployerAppService : CrudAppService<Employer, EmployerDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEmployerDto, CreateUpdateEmployerDto>,
        IEmployerAppService
    {
        protected override string GetPolicyName { get; set; } = FindJobPermissions.Employer.Default;
        protected override string GetListPolicyName { get; set; } = FindJobPermissions.Employer.Default;
        protected override string CreatePolicyName { get; set; } = FindJobPermissions.Employer.Create;
        protected override string UpdatePolicyName { get; set; } = FindJobPermissions.Employer.Update;
        protected override string DeletePolicyName { get; set; } = FindJobPermissions.Employer.Delete;

        private readonly IEmployerRepository _repository;
        private readonly IPostRepository _postRepository;
        private readonly IIdentityUserRepository _userRepository;
        
        
        public EmployerAppService(
            IEmployerRepository repository, 
            IPostRepository postRepository,
            IIdentityUserRepository userRepository) : base(repository)
        {
            _repository = repository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<string[]> getTop3Employer()
        {
            var allEmployer = await _repository.GetListAsync();
            var allPost = await _postRepository.GetListAsync();
            List<int> listCount = new List<int>();
            foreach(var employer in allEmployer)
            {
                var count = 0;
                foreach(var post in allPost)
                {
                    if(post.IdUser == employer.IdUser)
                    {
                        count++;
                    }
                }
                listCount.Add(count);
            }
            listCount.Sort();
            var arr = listCount.ToArray();
            string[] rs = new string[3];
            foreach (var employer in allEmployer)
            {
                var count = 0;
                foreach (var post in allPost)
                {
                    if (post.IdUser == employer.IdUser)
                    {
                        count++;
                    }
                }
                if(count==arr[listCount.Count-1])
                {
                    rs[0] = employer.CompanyName;
                }
                if(count==arr[listCount.Count-2])
                {
                    rs[1] = employer.CompanyName;
                }
                if(count==arr[listCount.Count-3])
                {
                    rs[2] = employer.CompanyName;
                }
            }
            return rs;
        }

        public async Task<PagedResultDto<EmployerDto>> GetListEmployerAsync(GetInputEmployer input)
        {
            var Employers = await _repository.GetListEmployerAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            List<EmployerDto> EmployersDto = new List<EmployerDto>();

            foreach (var item in Employers)
            {
                EmployerDto EmployerDto = new EmployerDto();
                EmployerDto.Id = item.Id;
                EmployerDto.IdUser = item.IdUser;
                EmployerDto.CompanyName = item.CompanyName;
                EmployerDto.Address = item.Address;
                var user = await _userRepository.FindAsync(item.IdUser);
                EmployerDto.Username = user.UserName;
                EmployersDto.Add(EmployerDto);
            }

            var totalCount = input.Filter == null
                ? await _repository.CountAsync()
                : await _repository.CountAsync(
                    field => field.IdUser.ToString().Contains(input.Filter));

            return new PagedResultDto<EmployerDto>(
                totalCount,
                EmployersDto
            );
        }

        public async Task<int[]> getNumberTop3Employer()
        {
            var allEmployer = await _repository.GetListAsync();
            var allPost = await _postRepository.GetListAsync();
            List<int> listCount = new List<int>();
            foreach (var employer in allEmployer)
            {
                var count = 0;
                foreach (var post in allPost)
                {
                    if (post.IdUser == employer.IdUser)
                    {
                        count++;
                    }
                }
                listCount.Add(count);
            }
            listCount.Sort();
            var arr = listCount.ToArray();
            int[] rs = new int[3];
            rs[0] = arr[listCount.Count - 1];
            rs[1] = arr[listCount.Count - 2];
            rs[2] = arr[listCount.Count - 3];
            return rs;
        }
    }
}
