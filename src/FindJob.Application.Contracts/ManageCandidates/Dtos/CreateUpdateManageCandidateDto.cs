using System;
using System.ComponentModel;
namespace FindJob.ManageCandidates.Dtos
{
    [Serializable]
    public class CreateUpdateManageCandidateDto
    {
        public Guid IdCV { get; set; }

        public Guid IdEmployer { get; set; }

        public bool Status { get; set; }
    }
}