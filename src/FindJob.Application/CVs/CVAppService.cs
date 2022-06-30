using System;
using FindJob.Permissions;
using FindJob.CVs.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using FindJob.Fields;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace FindJob.CVs
{
    public class CVAppService : CrudAppService<CV, CVDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCVDto, CreateUpdateCVDto>,
        ICVAppService
    {
        protected override string GetPolicyName { get; set; } = FindJobPermissions.CV.Default;
        protected override string GetListPolicyName { get; set; } = FindJobPermissions.CV.Default;
        protected override string CreatePolicyName { get; set; } = FindJobPermissions.CV.Create;
        protected override string UpdatePolicyName { get; set; } = FindJobPermissions.CV.Update;
        protected override string DeletePolicyName { get; set; } = FindJobPermissions.CV.Delete;

        private readonly ICVRepository _repository;
        private readonly IFieldRepository _fieldRepository;
        private readonly IIdentityUserRepository _userRepository;



        public CVAppService(ICVRepository repository, IFieldRepository fieldRepository, IIdentityUserRepository userRepository) : base(repository)
        {
            _repository = repository;
            _fieldRepository = fieldRepository;
            _userRepository = userRepository;
        }

        public async Task<PagedResultDto<CVDto>> GetListCVAsync(GetInputCV input)
        {
            var CVs = await _repository.GetListCVAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter,
                input.IdField
            );

            List<CVDto> CVsDto = new List<CVDto>();

            foreach (var item in CVs)
            {
                CVDto CVDto = new CVDto();
                CVDto.Id = item.Id;
                CVDto.IdUser = item.IdUser;
                CVDto.IdField = item.IdField;
                CVDto.Content = item.Content;
                CVDto.Status = item.Status;
                CVDto.IsRead = item.IsRead;
                if (item.IdField != Guid.Empty)
                {
                    CVDto.FieldName = (await _fieldRepository.FindAsync((Guid)item.IdField)).Name;
                }
                else
                {
                    CVDto.FieldName = "";
                }
                if (CVDto.IdUser != Guid.Empty)
                {
                    var user = await _userRepository.FindAsync(CVDto.IdUser);
                    CVDto.FullName = user.Surname + " " + user.Name;
                }
                CVsDto.Add(CVDto);


            }

            var totalCount = input.Filter == null
                ? await _repository.CountAsync()
                : await _repository.CountAsync(
                    field => field.IdUser.ToString().Contains(input.Filter));

            return new PagedResultDto<CVDto>(
                totalCount,
                CVsDto
            );
        }

        public async Task ChangeStatus(Guid Id)
        {
            var CV = await _repository.FindAsync(Id);
            CV.Status = !CV.Status;
            await _repository.UpdateAsync(CV);
        }

        public async Task<int[]> getNumberCV()
        {
            var allCV = await _repository.GetListAsync();
            int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0, t10 = 0, t11 = 0, t12 = 0;
            foreach (var cv in allCV)
            {
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 1)
                    t1++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 2)
                    t2++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 3)
                    t3++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 4)
                    t4++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 5)
                    t5++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 6)
                    t6++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 7)
                    t7++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 8)
                    t8++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 9)
                    t9++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 10)
                    t10++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 11)
                    t11++;
                if (cv.CreationTime.Year == 2022 && cv.CreationTime.Month == 12)
                    t12++;
            }
            int[] result = new int[12];
            result[0] = t1;
            result[1] = t2;
            result[2] = t3;
            result[3] = t4;
            result[4] = t5;
            result[5] = t6;
            result[6] = t7;
            result[7] = t8;
            result[8] = t9;
            result[9] = t10;
            result[10] = t11;
            result[11] = t12;
            return result;
        }
    }
}
