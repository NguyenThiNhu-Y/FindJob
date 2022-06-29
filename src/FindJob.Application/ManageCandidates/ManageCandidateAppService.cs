using System;
using FindJob.Permissions;
using FindJob.ManageCandidates.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace FindJob.ManageCandidates
{
    public class ManageCandidateAppService : CrudAppService<ManageCandidate, ManageCandidateDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateManageCandidateDto, CreateUpdateManageCandidateDto>,
        IManageCandidateAppService
    {
        protected override string GetPolicyName { get; set; } = FindJobPermissions.ManageCandidate.Default;
        protected override string GetListPolicyName { get; set; } = FindJobPermissions.ManageCandidate.Default;
        protected override string CreatePolicyName { get; set; } = FindJobPermissions.ManageCandidate.Create;
        protected override string UpdatePolicyName { get; set; } = FindJobPermissions.ManageCandidate.Update;
        protected override string DeletePolicyName { get; set; } = FindJobPermissions.ManageCandidate.Delete;

        private readonly IManageCandidateRepository _repository;
        private readonly IIdentityUserRepository _userRepository;
        
        public ManageCandidateAppService(IManageCandidateRepository repository, IIdentityUserRepository userRepository) : base(repository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<int[]> getAllUser()
        {
            var allUser = await _userRepository.GetListAsync();
            int t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0, t7 = 0, t8 = 0, t9 = 0, t10 = 0, t11 = 0, t12 = 0;
            foreach (var user in allUser)
            {
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 1)
                    t1++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 2)
                    t2++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 3)
                    t3++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 4)
                    t4++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 5)
                    t5++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 6)
                    t6++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 7)
                    t7++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 8)
                    t8++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 9)
                    t9++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 10)
                    t10++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 11)
                    t11++;
                if (user.CreationTime.Year == 2022 && user.CreationTime.Month == 12)
                    t12++;
            }
            int[] result = new int[12];
            result[0] = t1 ;
            result[1] = t2 ;
            result[2] = t3 ;
            result[3] = t4 ;
            result[4] = t5 ;
            result[5] = t6 ;
            result[6] = t7 ;
            result[7] = t8 ;
            result[8] = t9 ;
            result[9] = t10 ;
            result[10] = t11 ;
            result[11] = t12 ;
            return result;
        }
    }
}
