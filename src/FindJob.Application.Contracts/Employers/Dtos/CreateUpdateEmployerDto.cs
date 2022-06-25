using System;
using System.ComponentModel;
namespace FindJob.Employers.Dtos
{
    [Serializable]
    public class CreateUpdateEmployerDto
    {
        public Guid IdUser { get; set; }
    }
}