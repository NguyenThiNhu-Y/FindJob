using System;
using System.ComponentModel;
namespace FindJob.Notifies.Dtos
{
    [Serializable]
    public class CreateUpdateNotifyDto
    {
        public string Content { get; set; }

        public Guid IdCV { get; set; }

        public bool Status { get; set; }
    }
}