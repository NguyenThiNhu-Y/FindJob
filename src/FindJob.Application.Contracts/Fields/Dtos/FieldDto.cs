using System;
using Volo.Abp.Application.Dtos;

namespace FindJob.Fields.Dtos
{
    [Serializable]
    public class FieldDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string ParentField { get; set; }

        public Guid? IdParentField { get; set; }
    }
}