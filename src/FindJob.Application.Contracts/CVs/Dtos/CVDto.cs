using System;
using Volo.Abp.Application.Dtos;

namespace FindJob.CVs.Dtos
{
    [Serializable]
    public class CVDto : FullAuditedEntityDto<Guid>
    {
        public string Content { get; set; }

        public bool Status { get; set; }

        public Guid IdUser { get; set; }

        public Guid IdField { get; set; }

        public string FileName { get; set; }
    }
}