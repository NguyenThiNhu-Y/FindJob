using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FindJob.Employers
{
    public class Employer: FullAuditedEntity<Guid> 
    {
        public Guid IdUser { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }

        public Employer()
        {
        }

        public Employer(
            Guid id,
            Guid idUser,
            string companyName,
            string address
        ) : base(id)
        {
            IdUser = idUser;
            CompanyName = companyName;
            Address = address;
        }
    }
}
