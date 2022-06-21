using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FindJob.Notifies
{
    public class Notify : FullAuditedEntity<Guid>
    {
        public string Content { get; set; }
        public Guid IdCV { get; set; }
        public bool Status { get; set; }

        protected Notify()
        {
        }

        public Notify(
            Guid id,
            string content,
            Guid idCV,
            bool status
        ) : base(id)
        {
            Content = content;
            IdCV = idCV;
            Status = status;
        }
    }
}
