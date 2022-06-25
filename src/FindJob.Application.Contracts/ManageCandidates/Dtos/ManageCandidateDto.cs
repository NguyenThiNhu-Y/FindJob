using System;
using Volo.Abp.Application.Dtos;

namespace FindJob.ManageCandidates.Dtos
{
    [Serializable]
    public class ManageCandidateDto : FullAuditedEntityDto<Guid>
    {
        public Guid IdCV { get; set; }

        public Guid IdEmployer { get; set; }

        public bool Status { get; set; }
    }
}