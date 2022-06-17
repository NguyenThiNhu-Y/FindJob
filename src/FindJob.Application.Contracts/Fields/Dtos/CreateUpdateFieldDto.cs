using System;
using System.ComponentModel;
namespace FindJob.Fields.Dtos
{
    [Serializable]
    public class CreateUpdateFieldDto
    {
        public string Name { get; set; }

        public Guid? IdParentField { get; set; }
    }
}