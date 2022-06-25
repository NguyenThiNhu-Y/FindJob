using System;
using Volo.Abp.Application.Dtos;

namespace FindJob.Employers.Dtos
{
    [Serializable]
    public class EmployerDto : FullAuditedEntityDto<Guid>
    {
        public Guid IdUser { get; set; }
    }
}