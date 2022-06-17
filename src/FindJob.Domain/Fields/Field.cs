using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FindJob.Fields
{
    public class Field : FullAuditedEntity<Guid> 
    {
        public string Name { get; set; }
        public Guid? IdParentField { get; set; }

        
        

        protected Field()
        {
        }

        public Field(
            Guid id,
            string name,
            Guid? idParentField
        ) : base(id)
        {
            Name = name;
            IdParentField = idParentField;
        }
    }
}
