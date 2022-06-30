using System;
using Volo.Abp.Application.Dtos;

namespace FindJob.Employers.Dtos
{
    [Serializable]
    public class EmployerDto : FullAuditedEntityDto<Guid>
    {
        public Guid IdUser { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }
        public string Username { get; set; }
    }
}