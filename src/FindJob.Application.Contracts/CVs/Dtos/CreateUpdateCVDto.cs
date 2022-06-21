using System;
using System.ComponentModel;
namespace FindJob.CVs.Dtos
{
    [Serializable]
    public class CreateUpdateCVDto
    {
        public string Content { get; set; }

        public bool Status { get; set; }

        public Guid IdUser { get; set; }

        public Guid IdField { get; set; }

        public string FileName { get; set; }
        public bool IsRead { get; set; }

    }
}