using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FindJob.Employers
{
    public class Employer : FullAuditedEntity<Guid>
    {
        public Guid IdUser { get; set; }

        protected Employer()
        {
        }

        public Employer(
            Guid id,
            Guid idUser
        ) : base(id)
        {
            IdUser = idUser;
        }
    }
}
