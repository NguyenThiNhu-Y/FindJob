using System;
using System.ComponentModel;
namespace FindJob.Employers.Dtos
{
    [Serializable]
    public class CreateUpdateEmployerDto
    {
        public Guid IdUser { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }
    }
}