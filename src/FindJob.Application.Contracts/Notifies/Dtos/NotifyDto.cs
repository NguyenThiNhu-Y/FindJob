using System;
using Volo.Abp.Application.Dtos;

namespace FindJob.Notifies.Dtos
{
    [Serializable]
    public class NotifyDto : FullAuditedEntityDto<Guid>
    {
        public string Content { get; set; }

        public Guid IdCV { get; set; }

        public bool Status { get; set; }

        public string FieldName { get; set; }
    }
}