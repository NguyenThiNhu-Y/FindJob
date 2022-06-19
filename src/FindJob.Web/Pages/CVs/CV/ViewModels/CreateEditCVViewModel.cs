using System;

using System.ComponentModel.DataAnnotations;

namespace FindJob.Web.Pages.CVs.CV.ViewModels
{
    public class CreateEditCVViewModel
    {
        [Display(Name = "CVContent")]
        public string Content { get; set; }

        [Display(Name = "CVStatus")]
        public bool Status { get; set; }

        [Display(Name = "CVIdUser")]
        public Guid IdUser { get; set; }

        [Display(Name = "CVIdField")]
        public Guid IdField { get; set; }

        [Display(Name = "CVFileName")]
        public string FileName { get; set; }
    }
}