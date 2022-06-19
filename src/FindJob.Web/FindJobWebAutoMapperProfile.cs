using FindJob.Fields.Dtos;
using FindJob.Web.Pages.Fields.Field.ViewModels;
using FindJob.Posts.Dtos;
using FindJob.Web.Pages.Posts.Post.ViewModels;
using FindJob.CVs.Dtos;
using FindJob.Web.Pages.CVs.CV.ViewModels;
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
        }
    }
}
