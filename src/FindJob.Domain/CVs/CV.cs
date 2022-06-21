using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FindJob.CVs
{
    public class CV : FullAuditedEntity<Guid>
    {
        public string Content { get; set; }
        public bool Status { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdField { get; set; }
        public string FileName { get; set; }
        public bool IsRead { get; set; }

        protected CV()
        {
        }

        public CV(
            Guid id,
            string content,
            bool status,
            Guid idUser,
            Guid idField,
            string fileName
        ) : base(id)
        {
            Content = content;
            Status = status;
            IdUser = idUser;
            IdField = idField;
            FileName = fileName;
        }
    }
}
