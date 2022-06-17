using FindJob.Fields;
using FindJob.Fields.Dtos;
using FindJob.Posts;
using FindJob.Posts.Dtos;
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
        }
    }
}
