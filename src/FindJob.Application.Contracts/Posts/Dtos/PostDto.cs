using System;
using Volo.Abp.Application.Dtos;

namespace FindJob.Posts.Dtos
{
    [Serializable]
    public class PostDto : FullAuditedEntityDto<Guid>
    {
        public string Content { get; set; }

        public bool Status { get; set; }

        public Guid IdUser { get; set; }

        public Guid IdField { get; set; }

        public string FileName { get; set; }
        public string FieldName { get; set; }
        public string FullName { get; set; }
    }
}