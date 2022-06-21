using System;

using System.ComponentModel.DataAnnotations;

namespace FindJob.Web.Pages.Notifies.Notify.ViewModels
{
    public class CreateEditNotifyViewModel
    {
        [Display(Name = "NotifyContent")]
        public string Content { get; set; }

        [Display(Name = "NotifyIdCV")]
        public Guid IdCV { get; set; }

        [Display(Name = "NotifyStatus")]
        public bool Status { get; set; }
    }
}