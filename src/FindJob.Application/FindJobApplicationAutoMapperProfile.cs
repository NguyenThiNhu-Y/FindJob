using FindJob.Fields;
using FindJob.Fields.Dtos;
using FindJob.Posts;
using FindJob.Posts.Dtos;
using FindJob.CVs;
using FindJob.CVs.Dtos;
using FindJob.Notifies;
using FindJob.Notifies.Dtos;
using FindJob.ManageCandidates;
using FindJob.ManageCandidates.Dtos;
using FindJob.Employers;
using FindJob.Employers.Dtos;
using AutoMapper;

namespace FindJob
{
    public class FindJobApplicationAutoMapperProfile : Profile
    {
        public FindJobApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Field, FieldDto>();
            CreateMap<CreateUpdateFieldDto, Field>(MemberList.Source);
            CreateMap<Post, PostDto>();
            CreateMap<CreateUpdatePostDto, Post>(MemberList.Source);

            CreateMap<CV, CVDto>();
            CreateMap<CreateUpdateCVDto, CV>(MemberList.Source);
            CreateMap<Notify, NotifyDto>();
            CreateMap<CreateUpdateNotifyDto, Notify>(MemberList.Source);
            CreateMap<ManageCandidate, ManageCandidateDto>();
            CreateMap<CreateUpdateManageCandidateDto, ManageCandidate>(MemberList.Source);
            CreateMap<Employer, EmployerDto>();
            CreateMap<CreateUpdateEmployerDto, Employer>(MemberList.Source);
        }
    }
}
