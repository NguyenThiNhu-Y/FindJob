using System;
using System.ComponentModel;
namespace FindJob.Posts.Dtos
{
    [Serializable]
    public class CreateUpdatePostDto
    {
        public string Content { get; set; }

        public bool Status { get; set; }

        public Guid IdUser { get; set; }

        public Guid IdField { get; set; }

        public string FileName { get; set; }
    }
}