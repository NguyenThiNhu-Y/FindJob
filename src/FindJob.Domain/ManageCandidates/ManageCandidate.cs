using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FindJob.ManageCandidates
{
    public class ManageCandidate : FullAuditedEntity<Guid>
    {
        public Guid IdCV { get; set; }
        public Guid IdEmployer { get; set; }
        public bool Status { get; set; }

        protected ManageCandidate()
        {
        }

        public ManageCandidate(
            Guid id,
            Guid idCV,
            Guid idEmployer,
            bool status
        ) : base(id)
        {
            IdCV = idCV;
            IdEmployer = idEmployer;
            Status = status;
        }
    }
}
