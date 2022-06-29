using FindJob.Fields.Dtos;
using FindJob.Web.Pages.Fields.Field.ViewModels;
using FindJob.Posts.Dtos;
using FindJob.Web.Pages.Posts.Post.ViewModels;
using FindJob.CVs.Dtos;
using FindJob.Web.Pages.CVs.CV.ViewModels;
using FindJob.Notifies.Dtos;
using FindJob.Web.Pages.Notifies.Notify.ViewModels;
using FindJob.ManageCandidates.Dtos;
using FindJob.Web.Pages.ManageCandidates.ManageCandidate.ViewModels;
using FindJob.Employers.Dtos;
using FindJob.Web.Pages.Employers.Employer.ViewModels;
using AutoMapper;

namespace FindJob.Web
{
    public class FindJobWebAutoMapperProfile : Profile
    {
        public FindJobWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<FieldDto, CreateEditFieldViewModel>();
            CreateMap<CreateEditFieldViewModel, CreateUpdateFieldDto>();
            CreateMap<PostDto, CreateEditPostViewModel>();
            CreateMap<CreateEditPostViewModel, CreateUpdatePostDto>();

            CreateMap<CVDto, CreateEditCVViewModel>();
            CreateMap<CreateEditCVViewModel, CreateUpdateCVDto>();
            CreateMap<FindJob.CVs.CV, CreateEditCVViewModel>();

            CreateMap<NotifyDto, CreateEditNotifyViewModel>();
            CreateMap<CreateEditNotifyViewModel, CreateUpdateNotifyDto>();

            CreateMap<ManageCandidateDto, CreateEditManageCandidateViewModel>();
            CreateMap<CreateEditManageCandidateViewModel, CreateUpdateManageCandidateDto>();
            CreateMap<EmployerDto, CreateEditEmployerViewModel>();
            CreateMap<CreateEditEmployerViewModel, CreateUpdateEmployerDto>();
        }
    }
}
