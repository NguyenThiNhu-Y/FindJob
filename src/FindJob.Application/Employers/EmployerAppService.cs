using System;
using FindJob.Permissions;
using FindJob.Employers.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using FindJob.Posts;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;

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
        
        
        public EmployerAppService(IEmployerRepository repository, IPostRepository postRepository) : base(repository)
        {
            _repository = repository;
            _postRepository = postRepository;
        }

        public async Task<string[]> top3Employer()
        {
            var allEmployer = await _postRepository.GetListAsync();
            var allPost = await _postRepository.GetListAsync();
            List<int> listCount = new List<int>();
            foreach(var employer in allEmployer)
            {
                var count = 0;
                foreach(var post in allPost)
                {
                    if(post.IdUser == employer.Id)
                    {
                        count++;
                    }
                }
                listCount.Add(count);
            }
            listCount.Sort();
            var arr = listCount.ToArray();
            string[] rs = new string[3];
            int i = 0;
            foreach (var employer in allEmployer)
            {
                var count = 0;
                foreach (var post in allPost)
                {
                    if (post.IdUser == employer.Id)
                    {
                        count++;
                    }
                }
                if(count==arr[listCount.Count-1] || count == arr[listCount.Count - 2] || count == arr[listCount.Count - 3])
                {
                    rs[i++] = employer.Id.ToString();
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

            foreach (var item in EmployersDto)
            {
                EmployerDto EmployerDto = new EmployerDto();
                EmployerDto.Id = item.Id;
                EmployerDto.IdUser = item.IdUser;
                EmployerDto.CompanyName = item.CompanyName;
                EmployerDto.Address = item.Address;
                //if (item.IdField != Guid.Empty)
                //{
                //    EmployerDto.FieldName = (await _fieldRepository.FindAsync((Guid)item.IdField)).Name;
                //}
                //else
                //{
                //    EmployerDto.FieldName = "";
                //}
                //if (EmployerDto.IdUser != Guid.Empty)
                //{
                //    EmployerDto.FullName = CurrentUser.SurName + " " + CurrentUser.Name;
                //}
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
    }
}
